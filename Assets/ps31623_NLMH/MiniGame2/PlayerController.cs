using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public LayerMask wallLayer;
    public LayerMask boxLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector2.up);      
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector2.down);    
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector2.left);    
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector2.right);   
    }

    void Move(Vector2 direction)
    {
        Vector2 newPosition = (Vector2)transform.position + direction;

        // Kiểm tra tường
        if (Physics2D.OverlapCircle(newPosition, 0.1f, wallLayer))

            return;

        Collider2D box = Physics2D.OverlapCircle(newPosition, 0.1f, boxLayer);
        if (box != null)
        {
            Vector2 boxNewPosition = newPosition + direction;
            if (Physics2D.OverlapCircle(boxNewPosition, 0.1f, wallLayer) ||
                Physics2D.OverlapCircle(boxNewPosition, 0.1f, boxLayer))
            {
                return;
            }

            box.transform.position = boxNewPosition; 
        }

        transform.position = newPosition;
    }
}

