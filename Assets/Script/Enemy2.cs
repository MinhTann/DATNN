using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 10f;
    [SerializeField] private int damage;
    [SerializeField] private float Range;
     [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private Animator animator;

    private Health playerHealth;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
      
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerinSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("Attack");
                
            }
        }


    }
    private bool PlayerinSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * Range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * Range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * Range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    public void TakeDame()
    {
        animator.SetTrigger("Hit");

    }
    private void DamePlayer()
    {
        if (PlayerinSight())
        {
           playerHealth.TakeDame(damage);
        }
    }
}
