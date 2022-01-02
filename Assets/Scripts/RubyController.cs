using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    // fix shaking
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;


    // Start is called before the first frame update
    void Start()
    {

        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;

        // fix shaking by rigidbody2d.position
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       
        // Vector2 position = transform.position;
        // position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        // position.y = position.y + 3.0f * vertical * Time.deltaTime;
        // transform.position = position;

    }

    // physics system is updated at a different rate than the game. Update is called every time the game computes a new image
    // For the physics computation to be stable
    void FixedUpdate()
    {

        // fix shaking by rigidbody2d.position
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

}
