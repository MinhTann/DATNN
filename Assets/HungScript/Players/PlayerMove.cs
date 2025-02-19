using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    private float Movement = 0f;
    public float moveSpeed = 10f;
    public bool isRight = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       

    }
    // Update is called once per frame
    void Update()
        {
            Movement = Input.GetAxisRaw("Horizontal");
            if (Movement < 0f && isRight)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                isRight = false;
            }
            else if (Movement > 0f && isRight == false)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                isRight = true;
            }

           
        }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Movement, 0f, 0f) * Time.fixedDeltaTime * moveSpeed;
    }
}
