using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleTrap : MonoBehaviour
{

    public float speed;
    public float speedRun;
    public Transform diemA;
    public Transform diemB;
    private Vector3 diemMuctieu;

    void Start()
    {
        diemMuctieu = diemA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, diemMuctieu, speedRun*Time.deltaTime);
        if(Vector3.Distance(transform.position, diemMuctieu) <0.1){


            if(transform.position == diemA.position ){
                diemMuctieu = diemB.position;
            }
            else{
                diemMuctieu = diemA.position;
            }
        }
    }
            

        
    
    private void FixedUpdate()
    {
        transform.Rotate(0,0, speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
        SceneManager.LoadScene("Map1");
        }
    }
}
