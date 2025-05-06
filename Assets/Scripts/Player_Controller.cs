using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float move_speed = 10;
    private InputSystem_Actions input;
    public Vector3 jump;
    public float jumpForce;
    public bool isGrounded;
    Rigidbody2D rb;
    public Player_ActivateColors ColorScript;
    public Transform groundSensor;
    public LayerMask groundCheckLayerMask;
    public float groundCheckDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();

        rb = GetComponent<Rigidbody2D>();
    	jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = RaycastFromSensor(groundSensor);
        transform.Translate(Vector3.right * move_speed * input.Player.Move_Right.ReadValue<float>() * Time.deltaTime);
        transform.Translate(Vector3.left * move_speed * input.Player.Move_Left.ReadValue<float>() * Time.deltaTime);

        if((input.Player.Jump.ReadValue<float>() != 0) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hold on to it
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Bleh
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlugR"))
        {
            ColorScript.red = true;
        }
        if (collision.gameObject.CompareTag("PlugG"))
        {
            ColorScript.green = true;
        }
        if (collision.gameObject.CompareTag("PlugB"))
        {
            ColorScript.blue = true;
        }
        if (collision.gameObject.CompareTag("Port1"))
        {
            ColorScript.portOne = true;
        }
        if (collision.gameObject.CompareTag("Port2"))
        {
            ColorScript.portTwo = true;
        }
        if (collision.gameObject.CompareTag("Port3"))
        {
            ColorScript.portThree = true;
        }
    }

    public bool RaycastFromSensor(Transform groundSensor)
    {
        RaycastHit2D hit;
        var position = groundSensor.position;
        var forward = groundSensor.forward;
        hit = Physics2D.Raycast(position, forward, groundCheckDistance, groundCheckLayerMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    public void ColorHandler()
    {
        //fill later
    }
}