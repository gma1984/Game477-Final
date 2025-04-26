using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatHide : MonoBehaviour
{

    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedSignal"))
        {
            physicalCollider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedSignal"))
        {
            physicalCollider.enabled = true;
        }
    }
}
