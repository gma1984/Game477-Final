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
        transform.Translate(Vector3.right * move_speed * input.Player.Move_Right.ReadValue<float>() * Time.deltaTime);
        transform.Translate(Vector3.left * move_speed * input.Player.Move_Left.ReadValue<float>() * Time.deltaTime);

        if((input.Player.Jump.ReadValue<float>() != 0) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
    		isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Hold on to it
    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    public void ColorHandler()
    {
        //fill later
    }
}