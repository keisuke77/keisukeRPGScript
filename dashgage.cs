using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashgage : MonoBehaviour
{
 
   
    public Animator anim;
    public GameObject Dust;
    [Range(0, 5)] public float durationTired = 2f;
    public mp mp;
    public float speedUpValue = 2f;
    public PlayerControll playerControll;
    public GroundCast groundCast;

    public float decreaseTime = 10f;
    private float tempSpeed;
    private bool isDashing;
    private bool isTired;
public bool FullVanish;
    private void Start()
    {
        StartCoroutine(DustSpawnCoroutine());
        tempSpeed = playerControll._speed;

      
    }

    private IEnumerator DustSpawnCoroutine()
    {
        while (true)
        {
            if (isDashing && groundCast.isGrounded)
            {
                Instantiate(Dust, groundCast.hit.point, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.4f);
        }
    }

  

    private void Update()
    {
        HandleDashing();

        if (mp.MP < 0)
        {
            HandleTiredState();
        }

       
        UpdateImageVisibility();

    }

    private void HandleDashing()
    {
        if (groundCast.isGrounded && !isTired && keiinput.Instance.dashduring && (anim.GetFloat("Speed") > 0.1f || anim.GetFloat("speed") > 0.1f))
        {

            isDashing = true;
            mp.MP -= mp.maxMP*Time.deltaTime / decreaseTime;
            playerControll._speed = tempSpeed * speedUpValue;
        }
        else
        {
            isDashing = false;
            playerControll._speed = tempSpeed;
        }
    }

    private void HandleTiredState()
    {
        anim.SetTrigger("tired");
        isTired = true;
        keikei.delaycall(() => isTired = false, durationTired);
    }

    private void UpdateImageVisibility()
    {
        if (FullVanish)
        {
              mp.mpimage.enabled = mp.MP != 1;
        }
      
    }

  
}
