using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPLayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float startingHealth;

    public float currenthealth {get; set;}
    void Start()
    {
        currenthealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            TakeDame(1);
        }
    }
    public void TakeDame(float dame)
    {
        currenthealth = Mathf.Clamp(currenthealth - dame, 0, startingHealth);

        if (currenthealth > 0)
        {
            //Hurt
        }
        else
        {
            //Die
        }
    }
}
