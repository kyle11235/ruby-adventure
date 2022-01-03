using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // Unity doesn’t run Start when you create the object, but on the next frame    
    void Start()
    {
        // rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Awake is called immediately when the object is created 
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        //we also add a debug log to know what the projectile touch
        Debug.Log("bullet Collision with " + other.gameObject);
        Destroy(gameObject);

    }

    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }


}

