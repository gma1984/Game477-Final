using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatHide : MonoBehaviour
{

    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("YellowSignal"))
        {
            physicalCollider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("YellowSignal"))
        {
            physicalCollider.enabled = true;
        }
    }
}
