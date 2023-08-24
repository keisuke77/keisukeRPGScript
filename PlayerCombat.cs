using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator; // Set this in the Inspector
    public int maxComboCount = 3;
    public float comboResetTime = 2f;
    
    private int comboCount;
    private float lastAttackTime;

    private void Update()
    {
        // In this example, pressing the attack button increases the combo count and plays the corresponding animation
        if (keiinput.Instance.attack)
        {
            comboCount++;
            lastAttackTime = Time.time;

            if (comboCount > maxComboCount)
            {    for (int i = 0; i < maxComboCount+1; i++)
         {
   animator.ResetTrigger($"Attack{i}");
           }  
                comboCount = 1; // reset combo count if it exceeds max
            }
       animator.SetTrigger($"Attack{comboCount}");
      
            // Trigger the corresponding attack animation
            }

        // Reset combo count if too much time has passed since the last attack
        if (Time.time > lastAttackTime + comboResetTime)
        {
            comboCount = 0;
        }
    }
}
