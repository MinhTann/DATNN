using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EvilBoss_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator ani;

    public GameObject player;
    public GameObject bulletPrefab;

    public float attackRange = 5f; // Khoảng cách tấn công

    private float attackTimer = 0f; // Thời gian tấn công

    [SerializeField] private bool checkGoAttack = false;
    public bool isOnRight;
    public bool _attackRun;
    public bool _evilIsAttack = true;

    public float bulletSpeed = 10f;
    public Transform gunTip;


    [SerializeField] private Health _evilHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        attackTimer += Time.deltaTime;
        if (attackTimer >= 5f)
        {
            //MoveTowardsPlayer();
            if(_evilIsAttack)
            {
                int s = Random.Range(0, 2);
                switch (s)
                {
                    case 0:
                        StartCoroutine(DemShoot());
                        //ShootAtPlayer();
                        break;
                    case 1:
                        AttackPlayer();
                        break;
                }
                //ShootAtPlayer();
                 //AttackPlayer();
            }
            attackTimer = 0f; 
        }
    }

    void AttackPlayer()
    {
        //int s = Random.Range(0, 1   );
        //switch (s)
        //{
        //    case 0:
        //        checkGoAttack = false;
        //        ani.SetTrigger("Evil_Run");
        //        break;
        //    case 1:
        //        ani.SetTrigger("Evil_Attack1");
        //        break;
        //}

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            ani.SetTrigger("Evil_Attack1");
           // ani.SetTrigger("Evil_Run");
            Debug.Log("....."+ distance);
        }
        else
        {
            checkGoAttack = false;
            ani.SetTrigger("Evil_Run");
            //ani.SetTrigger("Evil_Attack1"); // Tấn công khi ở trong khoảng cách tấn công
            Debug.Log("....." + distance);
        }
    }

    void FlipPlayer()
    {
        var x_boss = transform.position.x;
        var x_player = player.transform.position.x;
        if (!isOnRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        if (x_player < x_boss)
        {
            isOnRight = false;
        }
        if (x_player > x_boss)
        {
            isOnRight = true;
        }
    }

    IEnumerator MoveBoss()
    {
        while (checkGoAttack == false)
        {
            // Di chuyển boss
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * 4 * Time.deltaTime;
            yield return null; 
        }
    }

    void ShootAtPlayer()
    {

        //ani.SetTrigger("Fireball1");
        Debug.Log(" Có 1 viên đạn");
        // Tạo một đối tượng đạn mới
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);

        // Tính toán hướng bắn
        Vector3 direction = (player.transform.position + new Vector3(0,1.5f,0) - gunTip.position).normalized;

        // Đặt vận tốc cho đạn
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = direction * bulletSpeed;
        //Destroy(bullet, 4f);
    }
    private IEnumerator DemShoot()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 1; i <= 5; i++)
        {
            Debug.Log(" Viên đạn thứ : " + i);
            ShootAtPlayer();
            yield return new WaitForSeconds(0.8f);
        }
    }
    public void GoAttack()
    {
        StartCoroutine(MoveBoss());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Chạm player rồi nhá");
            ani.SetTrigger("Evil_Attack2");
            checkGoAttack = true;
        }

        if (collision.gameObject.tag == "PlayerAttack123")
        {
            if (_evilIsAttack)
            {
                _evilHealth.TakeDamage(10);
                if (_evilHealth.GetCurrenHealth() <= 0)
                {
                    _evilIsAttack = false;
                    Debug.Log("Boss đã hết máu......!");
                    ani.SetTrigger("Evil_Die");
                }
            }
        }
    }
    void CheckGoAttack()
    {
        checkGoAttack = true;
    }
    void EvilDie()
    {
        Destroy(gameObject);
    }
}
