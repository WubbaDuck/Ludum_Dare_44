using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderColliderChange : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Contains("Border"))
        {
            CircleCollider2D col = gameObject.GetComponent<CircleCollider2D>();
            gameObject.GetComponents<AudioSource>() [1].Play();
            col.isTrigger = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.IsTouchingLayers(LayerMask.GetMask("Interactables", "Hazards")))
        {
            if (!gameObject.GetComponents<AudioSource>() [1].isPlaying)
            {
                gameObject.GetComponents<AudioSource>() [1].Play();
            }
        }
    }
}
