using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilHealth_UI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health _evilHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = _evilHealth.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = _evilHealth.GetCurrenHealth();
    }
}
