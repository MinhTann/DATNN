using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public float healthAmout = 100f;

    public void TakeDame(float dame)
    {
        healthAmout -= dame;
        healthbar.fillAmount = healthAmout / 100f;
    }
    private void Update()
    {
       
    }
}
