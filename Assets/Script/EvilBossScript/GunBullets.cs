using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullets : MonoBehaviour
{
    //public GameObject player;
    public GameObject bulletPrefab;

    public float bulletSpeed = 10f;
    public Transform gunTip;

    private float updateShoot = 0f;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DemShoot());
    }

    // Update is called once per frame
    void Update()
    {
        updateShoot += Time.deltaTime;
        if(updateShoot >= 0.5)
        {
            ShootAtPlayer();
            i++;
            if (i == 6)
            {
                Destroy(gameObject);
            }
            updateShoot = 0f;
        }
        //Vector3 positionPlayer = player.transform.position;
    }
    public void ShootAtPlayer()
    {
        Vector3 posPlayer = FindObjectOfType<HeroKnight>().transform.position;
        //ani.SetTrigger("Fireball1");
        Debug.Log(" Có 1 viên đạn");
        // Tạo một đối tượng đạn mới
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);

        // Tính toán hướng bắn
        Vector3 direction = (posPlayer + new Vector3(0, 1f, 0) - gunTip.position).normalized;

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
            if(i == 5)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.8f);
        }
    }
}
