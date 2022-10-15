using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepos : MonoBehaviour
{
	enum MoveFunc
	{
		rotate,
		Lerp,
		Slerp,
		SmoothDamp,
		MoveTowards,
	}

	private Transform _transform;
	private Vector3 _startPos;
	private Vector3 _targetPos;
	private float _startTime;
	private Vector3 _velocity = Vector3.zero;
	
	public float SmoothTime = 2f;
	public float Speed = 1f;
	public float JourneyLength = 10f;
	public Vector3 localmoveto;
    private float _time;
	public float debuga;
    
    private float distCovered;

	[SerializeField]
	private MoveFunc _moveFunc;
	
	void Start ()
	{
		_transform = GetComponent<Transform>();
		_startPos = _transform.position;
		_targetPos = _startPos+localmoveto;
		_startTime = Time.time;
        JourneyLength = Vector3.Distance(_startPos,_targetPos);
	}
	
void changer(Vector3 a, Vector3 b)
        {
            b = a - b;
            a = a - b;
            b = a + b;
            _startPos=b;
            _targetPos=a;

        }

	void Update ()
	{
debuga=CalcMoveRatio();

        
		

		switch (_moveFunc)
		{
			case MoveFunc.Lerp:
				transform.position = Vector3.Lerp(_startPos, _targetPos, CalcMoveRatio());
				break;
				case MoveFunc.rotate:
				Vector3 ro= Vector3.Lerp(_startPos, _targetPos, CalcMoveRatio());
				transform.rotation = Quaternion.Euler(ro);
				break;

			case MoveFunc.Slerp:
				transform.position = Vector3.Slerp(_startPos, _targetPos, CalcMoveRatio());
				break;
			case MoveFunc.SmoothDamp:
				transform.position = Vector3.SmoothDamp(_transform.position, _targetPos, ref _velocity, SmoothTime);
				break;
			case MoveFunc.MoveTowards:
				var step = Speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(_transform.position, _targetPos, step);
				break;
			default:
				throw new Exception();
		}



	}

	float CalcMoveRatio()
	{ distCovered = distCovered + (Time.deltaTime* Speed);
      
       return Mathf.Abs(Mathf.Sin(distCovered*Mathf.PI / JourneyLength)) ;
			
	}
}