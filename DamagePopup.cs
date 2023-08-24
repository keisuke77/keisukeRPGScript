using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMesh textMesh;
    private Color textColor;
    private Transform playerTransform;

public float dissapearTimer = 0.5f;
    private float fadeOutSpeed = 5f;
    private float moveYSpeed = 1f;
    public Color defaultcolor;

	public void SetUp(int amount, Color textC)
    {
        SetUp(amount.ToString(),textC);
    }
    	public void SetUp(string amount, Color textC)
    {
        textMesh = GetComponent<TextMesh>();
        playerTransform = Camera.main.transform;
        textColor = textC;
        textMesh.text = amount.ToString();
        textMesh.color = textColor;
    }
public void SetUp(int amount)
    {
     SetUp(amount.ToString());
       }
public void SetUp(string st)
    {
       SetUp(st,defaultcolor);
      
    }

	private void LateUpdate()
	{
        if (textMesh != null)
        {
            transform.LookAt(2 * transform.position - playerTransform.position);
            transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f);
            dissapearTimer -= Time.deltaTime;
            
            if (dissapearTimer <= 0f)
            {
                textColor.a -= fadeOutSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if (textColor.a <= 0f)
                {
                    Destroy(gameObject);
                }
            }
        }
	}
}
