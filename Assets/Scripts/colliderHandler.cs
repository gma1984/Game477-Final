using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderHandler : MonoBehaviour
{
    bool canLeft = true;
    bool canRight = true;
    bool canUp = true;
    bool canDown = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canLeft = !canLeft;
            canRight = !canRight;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            canDown = !canDown;
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            canUp = !canUp;
        }
    }
}
