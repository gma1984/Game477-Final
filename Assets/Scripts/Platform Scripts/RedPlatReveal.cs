using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatReveal : MonoBehaviour
{

    public SpriteMask spriteMask;

    private bool maskActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedSignal"))
        {
            ToggleMask(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedSignal"))
        {
            ToggleMask(true);
        }
    }

    void ToggleMask(bool active)
    {
        maskActive = active;
        if (spriteMask != null)
        {
            spriteMask.enabled = active;
        }
    }
}
