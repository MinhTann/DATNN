using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatNhay : MonoBehaviour
{
    public float doNay;
    private SpriteRenderer mySpriteRen;

    void Start()
    {
        mySpriteRen = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*doNay, ForceMode2D.Impulse);

            mySpriteRen.color = Color.red;
        
        }
        
    }
    private void OiggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            mySpriteRen.color = Color.white;
        }
    }


}
