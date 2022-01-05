using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("house OnTriggerEnter2D");
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
            if (particles != null)
            {
                Debug.Log("particles != null");
                particles.Play();
                player.PlaySound(clip);
            }
        }

    }

}
