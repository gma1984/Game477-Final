using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlatReveal : MonoBehaviour
{

    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WhiteSignal"))
        {
            physicalCollider.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WhiteSignal"))
        {
            physicalCollider.enabled = false;
        }
    }
}
