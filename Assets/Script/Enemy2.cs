using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float Range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private Animator animator;
    private Player player;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerinSight())
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
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * Range * transform.localScale.x, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        
        
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * Range * transform.localScale.x, boxCollider.bounds.size);
    }
    public void TakeDame()
    {
        animator.SetTrigger("Hit");

    }
}
