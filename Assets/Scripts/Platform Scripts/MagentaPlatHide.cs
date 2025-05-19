using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentaPlatHide : MonoBehaviour
{

    public GameObject onParticles;
    public Collider2D physicalCollider;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MagentaSignal"))
        {
            physicalCollider.enabled = false;
            onParticles.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MagentaSignal"))
        {
            physicalCollider.enabled = true;
            onParticles.SetActive(true);
        }
    }
}
