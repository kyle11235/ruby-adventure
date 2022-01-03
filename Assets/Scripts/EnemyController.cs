using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    
    Animator animator;

    bool broken = true;

    public AudioClip fixedSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;

        animator = GetComponent<Animator>();

        audioSource = GetComponentInChildren<AudioSource>();
    }
    

    void Update()
    {
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {

        if(!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        
        rigidbody2D.MovePosition(position);
    }

    // Collision2D(other character e.g. ruby) not Collider2D(collectible object)
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            player.PlaySound(player.hitSound);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");

        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
        if (particles != null)
        {
            particles.Stop();
            audioSource.Stop();
            PlaySound(fixedSound);
        }

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


}
