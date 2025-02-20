using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    public float destroyClone;

    // Update is called once per frame
    void Update()
    {
        // Vector3 = (x ,y ,z)
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyClone)
        {
            Destroy(gameObject);
        }
    }
}
