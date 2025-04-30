using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyOne : MonoBehaviour
{
    public float move_speed = 5;
    public bool goingLeft = false;
    public bool goingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft && goingRight)
        {
            goingLeft = false;
            goingRight = true;
        }
        else if (!goingLeft && !goingRight)
        {
            goingLeft = false;
            goingRight = true;
        }
        if (goingRight)
            transform.position += (transform.right * move_speed * Time.deltaTime);
        else if (goingLeft)
            transform.position += (-transform.right * move_speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            goingLeft = !goingLeft;
            goingRight = !goingRight;
        }
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            goingLeft = !goingLeft;
            goingRight = !goingRight;
        }
    }*/
}