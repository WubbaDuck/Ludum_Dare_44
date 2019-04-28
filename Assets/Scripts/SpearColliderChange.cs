using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearColliderChange : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Contains("Border"))
        {
            PolygonCollider2D col = gameObject.GetComponent<PolygonCollider2D>();
            col.isTrigger = false;
        }
    }
}
