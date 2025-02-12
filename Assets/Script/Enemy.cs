using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    
    //private Rigidbody2D rb;
    private Animator animator;
   
    public Transform AttackPoint;
    private float AttackCountDown = 2f;
    private float AttackTimer;
    EnemyController enemyController;
    private float health = 100f;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (CheckAttack())
        {
            AttackTimer += Time.deltaTime;
            if (AttackTimer > AttackCountDown)
            {
                animator.SetTrigger("Attack");
                AttackTimer = 0;
            }
            
        }
        Dead();
       
    }
    public void TakeDame()
    {
        animator.SetTrigger("Hit");
        enemyController.dazedTime = enemyController.startDazedTime;
        health -= 20;

    }
    void Dead()
    {
        if(health == 0)
        {
            animator.SetBool("Die", true);
            enemyController.enabled = false;
            this.enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(transform.gameObject, 3f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AttackPoint.position ,new Vector3(2f, 0.5f, 2f));

    }
    private bool CheckAttack()
    {
        Collider2D[] col = Physics2D.OverlapBoxAll(AttackPoint.position, new Vector3(3f, 0.5f, 2f),0);
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
