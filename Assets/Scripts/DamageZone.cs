using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
            player.PlaySound(clip);
        }
    }

}

