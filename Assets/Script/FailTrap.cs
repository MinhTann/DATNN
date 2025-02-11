using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FailTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool fail = false;
     public Transform diemKhoiPhuc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& !fail){
            rb.velocity += new Vector2(0 , -0.05f);
            rb.isKinematic = false;
            fail = true;
            Invoke("KhoiPhuc", 2.5f);
        }
    }
    private void KhoiPhuc(){
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        transform.position = diemKhoiPhuc.position;
        fail = false;
    }
}
