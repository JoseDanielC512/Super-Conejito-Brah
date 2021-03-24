using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") ||
        collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
