using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOfGun : MonoBehaviour
{
    public GameObject DieBullet;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            Instantiate(DieBullet, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
