using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyScript : MonoBehaviour
{
    public GameObject Player;
    public float leftGo;
    public float rightGo;
    float speed = 2.0f; // Tốc độ di chuyển của quái vật
    private Vector3 startPos;
    private bool movingRight = true;
    public GameObject bulletPrefab; // Prefab của đạn 
    public Transform firePoint; // Điểm mà đạn sẽ được bắn ra private 
    public float fireRate = 2.0f; // Tần suất bắn (bắn một lần mỗi giây)
    private float nextFireTime = 0.0f;
    private bool isAttacking = false;
    public bool isOnRight;
    private bool checkisOnRight;
    Animator ani;
    int hit = 0;
    void Start()
    {
        ani = GetComponent<Animator>();
        startPos = transform.position;
    }
    void Update()
    {
        var x_boss = transform.position.x;
        var x_player = Player.transform.position.x;
        CheckPlayer();
        if (isAttacking)
        {

            if (x_player < x_boss)
            {
                isOnRight = true;
            }
            if (x_player > x_boss)
            {
                isOnRight = false;
            }
            FlipPlayer();
            AttackPlayer();
        }
        else
        {

            MoveMonster();
        }
    }
    void FlipPlayer()
    {
        //var x_boss = transform.position.x;
        //var x_player = Player.transform.position.x;
        if (isOnRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
    }
    void MoveMonster()
    {
        if (!movingRight)
        {
            isOnRight = true;
        }
        else
        {
            isOnRight = false;
        }
        FlipPlayer();
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= rightGo)
            {
                movingRight = false;
                // checkisOnRight = true;

            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= leftGo)
            {
                movingRight = true;
                //checkisOnRight = true;
            }
        }
    }
    void CheckPlayer()
    {
        if (Player.transform.position.x <= rightGo && Player.transform.position.x >= leftGo)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }
    void AttackPlayer()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            ani.SetTrigger("AttackFlyEnemy");
        }
    }
    void ShootPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        BulletFly bulletScript = bullet.GetComponent<BulletFly>();
        bulletScript.SetDirection(isOnRight);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAttack123")
        {
            Debug.Log("Có trúng damage");
            hit++;
            ani.SetTrigger("FlyHurt");
            if (hit > 3)
            {
                ani.SetTrigger("FlyDie");
            }
        }
    }
    void DestroyFlyEnemy() 
    { 
        Destroy(gameObject);
    }
}

