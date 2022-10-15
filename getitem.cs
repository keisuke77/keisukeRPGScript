using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitem : MonoBehaviour
{public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

void AllDEstroy()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("untagged");

        foreach (GameObject ball_Soccer in balls)
        {
            Destroy(ball_Soccer);
        }
    }


void OnCollisionEnter(Collision other)
	{

		
		if(other.gameObject.tag == "coin")	// プレイヤーとぶつかったとき
		{Destroy(other.gameObject);
score++;


        }}
    // Update is called once per frame
    void Update()
    {
       
          Application.Quit();
    }
}
