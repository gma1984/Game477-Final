using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatReveal : MonoBehaviour
{

    public GameObject onParticles;
    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlueSignal"))
        {
            physicalCollider.enabled = true;
            onParticles.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlueSignal"))
        {
            physicalCollider.enabled = false;
            onParticles.SetActive(false);
        }
    }
}
