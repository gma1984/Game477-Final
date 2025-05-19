using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatReveal : MonoBehaviour
{

    public GameObject onParticles;
    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GreenSignal"))
        {
            physicalCollider.enabled = true;
            onParticles.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GreenSignal"))
        {
            physicalCollider.enabled = false;
            onParticles.SetActive(false);
        }
    }
}
