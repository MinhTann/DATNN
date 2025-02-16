using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private float Movement = 0f;
    public float moveSpeed = 10f;
    public bool isRight = true;
    public float heightJP = 8f;
    public bool isGround = true;
    public float baseBossDamage = 100f; 
    private float currentBossDamage;
    public enum AttackState
    {
        None,
        Attack1,
        Attack2,
        Attack3
    }
    bool Activetime = true;
    float timer;
    float ActivetimeReset = 0.4f;
    private AttackState currentAttackState;
    float CountdownRoll = 4f;
    float Rolltimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = ActivetimeReset;
        currentAttackState = AttackState.None;
        CountdownRoll = Rolltimer;
        currentBossDamage = baseBossDamage;

    }
    // Update is called once per frame
    void Update()
        {
            Movement = Input.GetAxisRaw("Horizontal");
            if (Movement < 0f && isRight)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                isRight = false;
            }
            else if (Movement > 0f && isRight == false)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                isRight = true;
            }

            if (Mathf.Abs(Movement) > 0f)
            {
                animator.SetFloat("Run", 1f);
            }
            else
            {
                animator.SetFloat("Run", 0f);
            }
            if (Input.GetKey(KeyCode.Space) && isGround == true)
            {
                Jump();
                isGround = false;
                animator.SetBool("isGround", false);
            }
            Attack();
            ResetComboo();
            Rolltimer -= Time.deltaTime;
            Roll();
            BlocK();
        }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Movement, 0f, 0f) * Time.fixedDeltaTime * moveSpeed;
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0f, heightJP), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("isGround", true);
        }
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentAttackState++;
            Activetime = true;
            timer = ActivetimeReset;
            if (currentAttackState == AttackState.Attack1)
            {
                animator.SetTrigger("Attack1");
            }
            if (currentAttackState == AttackState.Attack2)
            {
                animator.SetTrigger("Attack2");
            }
            if (currentAttackState == AttackState.Attack3)
            {
                animator.SetTrigger("Attack3");
            }
        }
       

    }
    void ResetComboo()
    {
        if (Activetime == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentAttackState = AttackState.None;
                Activetime = false;
                timer = ActivetimeReset;
            }
        }
    }
    void Roll()
    {
        if (Rolltimer < 0f)
            return;

        if(Input.GetMouseButton(1))
        {
            animator.SetTrigger("Roll");
            Rolltimer = CountdownRoll;
        }
        
    }
    void BlocK()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("BlockIdle", true);
            moveSpeed = 0f;
        } else if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("BlockIdle", false);
            moveSpeed = 5f;
        }
    }

public IEnumerator BuffBossDamage(float bonus, float duration)
    {
        // Tăng sát thương
        currentBossDamage += bonus;
        Debug.Log($"[Buff]: Sát thương boss tăng lên {currentBossDamage} trong {duration} giây!");

        // Giữ hiệu ứng trong thời gian quy định
        yield return new WaitForSeconds(duration);

        // Trả lại sát thương ban đầu
        currentBossDamage = baseBossDamage;
        Debug.Log("[Buff]: Hết buff, sát thương boss trở lại: " + currentBossDamage);
    }

}
