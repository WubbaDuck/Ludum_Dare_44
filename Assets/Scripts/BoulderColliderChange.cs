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
            col.isTrigger = false;
        }
    }

}
