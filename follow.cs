using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class follow : MonoBehaviour
{
    [SerializeField] Transform targetPlayer = null;
    [SerializeField] float moveSpeed = 400f;
    [SerializeField] GameObject posGuidePrefab = null;
    [SerializeField] bool showGuide = false;
    [SerializeField] Transform neckBone = null;

    Rigidbody _rb;
    Animator _animator;
    Quaternion _targetRotation;

    Vector3 _targetPos;
    Vector3 _prevPlayerPos;
    Vector3 _moveForward;
    float _moveSpeedFactor = 0f;
    float _neckAngle = 0f;

    const int PosHistorySize = 16;
    Queue<Vector3> _playerPosHistory = new Queue<Vector3>();
    List<GameObject> _posGuides = new List<GameObject>();

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _targetRotation = Quaternion.Euler(0, 0, -1);
        InitPos();
    }

    void InitPos()
    {
        // 最初は自分の位置を目的地にしておく
        _targetPos = transform.position;
        _playerPosHistory.Enqueue(targetPlayer.position);

        for (int i = 0; i < PosHistorySize; ++i)
        {
            var guide = Instantiate(posGuidePrefab);
            guide.transform.position = transform.position;
            _posGuides.Add(guide);
        }
    }

    void Update()
    {
        UpdateTargetPos();
        ShortCutTargetPos();
        UpdateDebugMonitor();
        Turn();
    }

    void LateUpdate()
    {
        TurnNeck();
    }

    void FixedUpdate()
    {
        Move();
        FallAnimation();
    }

    //--------------------------------------------------------------------------
    // ターゲット位置関連
    //--------------------------------------------------------------------------

    void UpdateTargetPos()
    {
        Vector3 currentPlayerPos = targetPlayer.position;
        if (Vector3.Distance(currentPlayerPos, _prevPlayerPos) > 1.5f)
        {
            _prevPlayerPos = currentPlayerPos;
            if (_playerPosHistory.Count >= PosHistorySize)
            {
                _targetPos = _playerPosHistory.Dequeue();

                // たぶん引っかかってるのでワープさせちゃう
                transform.position = _targetPos;
            }
            _playerPosHistory.Enqueue(currentPlayerPos);
        }
    }

    /// <summary>
    /// ターゲットプレイヤーがすぐ近くにいたら律儀に位置履歴を追う必要がないので、
    /// ターゲット位置をターゲット近くのものに更新する
    /// </summary>
    void ShortCutTargetPos()
    {
        if (Vector3.Distance(transform.position, targetPlayer.position) < 7.0f &&
            _playerPosHistory.Count >= 4)
        {
            while (_playerPosHistory.Count > 4)
            {
                _playerPosHistory.Dequeue();
            }
            _targetPos = _playerPosHistory.Peek();
        }
    }

    void UpdateDebugMonitor()
    {
        _posGuides.ForEach(guide => guide.transform.localScale = Vector3.zero);
        if (!showGuide) { return; }

        int i = 0;
        foreach (Vector3 pos in _playerPosHistory)
        {
            _posGuides[i].transform.position = pos;
            float scale = 1.0f - ((_playerPosHistory.Count - i) * 0.07f);
            _posGuides[i].transform.localScale = new Vector3(scale, 0.1f, scale);
            ++i;
        }
    }

    //--------------------------------------------------------------------------
    // 移動処理
    //--------------------------------------------------------------------------

    void Move()
    {
        float animSpeed = (_moveSpeedFactor > 0.01f) ? _moveSpeedFactor * 0.3f : _moveSpeedFactor;
        _animator.SetFloat("Speed", animSpeed);

        // ターゲット本人が近くにいたら歩みを止める
        if (Vector3.Distance(transform.position, targetPlayer.position) < 3.5f)
        {
            ReduceSpeed();
            return;
        }

        // 近づいたら次のターゲット位置へ
        if (Vector3.Distance(transform.position, _targetPos) < 2.0f)
        {
            // ターゲット位置履歴が少なくなったら移動速度減衰させて追うのをやめる
            if (_playerPosHistory.Count <= 3)
            {
                ReduceSpeed();
                return;
            }
            _targetPos = _playerPosHistory.Dequeue();
        }

        float targetSpeedFactor = (_playerPosHistory.Count >= 5) ? 1.6f : 1f;
        if (_playerPosHistory.Count <= 2) { targetSpeedFactor = 0.5f; }
        UpdateMoveSpeedFactor(targetSpeedFactor);

        Vector3 moveForward = (_targetPos - transform.position).normalized;
        _moveForward = Vector3.Lerp(_moveForward, moveForward, 0.15f);
        float speed = moveSpeed * _moveSpeedFactor * Time.fixedDeltaTime;

        _rb.velocity = new Vector3(
            _moveForward.x * speed,
            _rb.velocity.y,
            _moveForward.z * speed
        );
        _targetRotation = Quaternion.LookRotation(new Vector3(_moveForward.x, 0, _moveForward.z));
    }

    void ReduceSpeed()
    {
        _rb.velocity = new Vector3(
            _rb.velocity.x * 0.9f,
            _rb.velocity.y,
            _rb.velocity.z * 0.9f
        );
        if (_moveSpeedFactor > 0.3f) { _moveSpeedFactor = 0.3f; }
        UpdateMoveSpeedFactor(0f);
    }

    void UpdateMoveSpeedFactor(float targetFactor)
    {
        if (_moveSpeedFactor < targetFactor)
        {
            _moveSpeedFactor += 0.02f;
        }
        else if (_moveSpeedFactor > targetFactor)
        {
            _moveSpeedFactor -= 0.02f;
        }
        _moveSpeedFactor = Mathf.Clamp(_moveSpeedFactor, 0f, 2f);
    }

    //--------------------------------------------------------------------------
    // 体の向き / 首の向き
    //--------------------------------------------------------------------------

    void Turn()
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, _targetRotation, 500f * Time.deltaTime
        );
    }

    /// <summary>
    /// プレイヤーの方に首を向ける
    /// </summary>
    void TurnNeck()
    {
        // 移動中は正面方向に戻す
        if (_moveSpeedFactor > 0.3f)
        {
            _neckAngle += (0 - _neckAngle) * 3f * Time.deltaTime;
            neckBone.Rotate(neckBone.rotation.x - 5f, _neckAngle, neckBone.rotation.z);
            return;
        }

        Vector3 dPos = targetPlayer.position - transform.position;
        Vector3 axis = Vector3.Cross(transform.forward, dPos);
        float yAngle = Vector3.Angle(transform.forward, dPos) * (axis.y < 0 ? -1 : 1);
        yAngle = Mathf.Clamp(yAngle, -50f, 50f);
        _neckAngle += (yAngle - _neckAngle) * 3f * Time.deltaTime;
        neckBone.Rotate(neckBone.rotation.x - 5f, _neckAngle, neckBone.rotation.z);
    }

    //--------------------------------------------------------------------------
    // 落下アニメ
    //--------------------------------------------------------------------------

    void FallAnimation()
    {
        bool isFalling = _rb.velocity.y < -4.0f;

        var pos = this.transform.position;
        RaycastHit raycastHit;
        if (Physics.Raycast(pos, Vector3.down, out raycastHit))
        {
            float distanceToGround = pos.y - raycastHit.point.y;
            if (distanceToGround > 1.0f && _rb.velocity.y < -0.5f) { isFalling = true; }
        }

        _animator.SetBool("IsFalling", isFalling);
    }
}