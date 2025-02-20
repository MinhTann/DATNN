using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public float speed = 2.5f; 
    public float destroyPosition = -6f; 

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyPosition)
        {
            Destroy(gameObject);
        }
    }
}
