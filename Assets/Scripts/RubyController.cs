using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{

    public float speed = 3.0f;

    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; }}

    // fix shaking
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject bulletPrefab;

    AudioSource audioSource;

    public AudioClip throwSound;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {

        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;

        // fix shaking by rigidbody2d.position
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        animator = GetComponent<Animator>();

        audioSource = GetComponentInChildren<AudioSource>();
        Debug.Log("started audioSource=" + audioSource);

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

        // animation
        Vector2 move = new Vector2(horizontal, vertical);
        
        // if != 0.0f
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize(); // make value to range [-1,1]
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // shoot bullet
        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }

    // physics system is updated at a different rate than the game. Update is called every time the game computes a new image
    // For the physics computation to be stable
    void FixedUpdate()
    {

        // fix shaking by rigidbody2d.position
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        if(currentHealth == 0){
            position.x = -18.42f;
            position.y = 15.38f;
        }

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            // this triggers animation state's transition's condition, a boolean value
            animator.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

    }

    void Launch()
    {
        // copy an instance (source, position, rotation)
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");

        PlaySound(throwSound);
    }

    public void PlaySound(AudioClip clip)
    {
        Debug.Log("clip=" + clip);
        Debug.Log("audioSource=" + audioSource);
        audioSource.PlayOneShot(clip);
    }

}
