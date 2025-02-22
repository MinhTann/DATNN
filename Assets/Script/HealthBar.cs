using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBars : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image Healtbar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Healtbar.fillAmount = PlayerHealth.currenthealth / 10;
    }
}
