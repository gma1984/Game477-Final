using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatReveal : MonoBehaviour
{

    public GameObject onParticles;
    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("YellowSignal"))
        {
            physicalCollider.enabled = true;
            onParticles.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("YellowSignal"))
        {
            physicalCollider.enabled = false;
            onParticles.SetActive(false);
        }
    }
}
