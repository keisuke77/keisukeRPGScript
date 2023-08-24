using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float blockDistance = 2f;
    [SerializeField] private float blockSize = 1f;
    [SerializeField] private LayerMask blockLayerMask;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // 左クリックでブロックを配置
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, blockDistance, blockLayerMask))
            {
                Vector3 newPosition = hit.point + hit.normal * blockSize * 0.5f;
                newPosition = new Vector3(Mathf.Round(newPosition.x), Mathf.Round(newPosition.y), Mathf.Round(newPosition.z));
                Instantiate(blockPrefab, newPosition, Quaternion.identity);
            }
        }

        // 右クリックでブロックを削除
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, blockDistance, blockLayerMask))
            {
                if (hit.collider.gameObject.CompareTag("Block"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
