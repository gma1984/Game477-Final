using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlatReveal : MonoBehaviour
{

    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PurpleSignal"))
        {
            physicalCollider.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PurpleSignal"))
        {
            physicalCollider.enabled = false;
        }
    }
}
