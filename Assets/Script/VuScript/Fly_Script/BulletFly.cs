using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 6f;
    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, 3);
    }
    public void SetDirection(bool isOnRight)
    {
        if (isOnRight)
        {
            direction = Vector2.left;
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else
        {
            direction = Vector2.right;
            Vector3 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
    }
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
