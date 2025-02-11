using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PointA;
    public Transform PointB;
    private bool isRight;
    [SerializeField] private float moveSpeed = 2f;
    //private Rigidbody2D rb;
    private Animator animator;
    private float idleTimer = 2f;
    private float timer;
    public Transform AttackPoint;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckAttack())
        {
            animator.SetTrigger("Attack");
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
        if(timer > idleTimer)
        {
            isRight = !isRight;
        }
     
    }
    public void TakeDame()
    {
        animator.SetTrigger("Hit");
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AttackPoint.position ,new Vector3(2f, 0.5f, 2f));

    }
    private bool CheckAttack()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(AttackPoint.position, new Vector3(2f, 0.5f, 2f),0);
        foreach (Collider2D col2 in col)
        {
            if (col2.gameObject.name == "Player")
            {
                return true;
            }
        }
        return false;
    }
   
}
