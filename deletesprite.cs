using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletesprite : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Disappearing());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Disappearing()
    {
        yield return new WaitForSeconds(10);
        int step = 90;
        for (int i = 0; i < step; i++)
        {
            spriteRenderer.material.color = new Color(1, 1, 1, 1 - 1.0f * i / step);
            yield return null;
        }
        Destroy(gameObject.root());
    }
}