using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Transform PointA;
    private Animator animator;
    public Transform PointB;
    private bool isRight;
    private float idleTimer = 2f;
    private float timer;
    [SerializeField] private float moveSpeed = 2f;
    public float dazedTime;
    public float startDazedTime = 0.6f;
 
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0)
        {
            moveSpeed = 2;
        } else
        {
            moveSpeed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (isRight)
        {
            if (transform.position.x >= PointA.position.x)
            {
                Move(-1);
                
            }
            else
            {
                ChangreDirection();
            }
        }
        else
        {
            if (transform.position.x <= PointB.position.x)
            {
                Move(1);
            }
            else
            {
                ChangreDirection();
            }

        }
    }
    void Move(int direction)
    {
        timer = 0f;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, transform.position.z);
        animator.SetBool("Moving", true);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * moveSpeed, transform.position.y, transform.position.z);
    }
    void ChangreDirection()
    {
        animator.SetBool("Moving", false);
        timer += Time.deltaTime;
        if (timer > idleTimer)
        {
            isRight = !isRight;
        }

    }
}
