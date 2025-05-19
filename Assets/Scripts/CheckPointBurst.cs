using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBurst : MonoBehaviour
{
    public ParticleSystem burst;
    private bool reset = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !reset)
        {
            burst.Play();
            reset = true;
            Invoke("ResetFlag", 3f);
        }
    }

    private void ResetFlag()
    {
        reset = false;
    }
}
