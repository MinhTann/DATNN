using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScropppWizard : MonoBehaviour
{
    public Transform Player;
    private Animator animator;

    [SerializeField] private float attackRange = 4f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 5f;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private int maxHeath;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Player.position, transform.position) <= attackRange)
        {
            AttackRandom();
            
        }
    }
    void AttackRandom()
    {
        int RandomAttack = Random.Range(0, 2);
        if (RandomAttack == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else
        {
            animator.SetTrigger("Attack2");
        }
    }
    public void Attack()
    {
        Collider2D collider = Physics2D.OverlapCircle(attackPoint.position,attackRadius,PlayerMask);
        if(collider)
        {
            Debug.Log("Player take dames");
        }
    }
    public void TakeDame(int dame)
    {
        maxHeath -= dame;
        if(maxHeath <= 0)
        {
            Die();
        } else
        {
            Hurt();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Die");
    }
    void Hurt()
    {
        Debug.Log("Enemy Hurt");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        if(attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
