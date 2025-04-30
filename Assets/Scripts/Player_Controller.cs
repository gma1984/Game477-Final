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

    public bool port_1_unlocked;
    public bool port_2_unlocked;
    public bool port_3_unlocked;

    public bool port_1_open;
    public bool port_2_open;
    public bool port_3_open;

    public bool red_active;
    public bool green_active;
    public bool blue_active;

    bool canLeft = true;
    int canLeftV = 1;
    bool canRight = true;
    int canRightV = 1;
    bool canUp = true;
    int canUpV = 1;
    bool canDown = true;
    int canDownV = 1;

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
        transform.Translate(Vector3.right * move_speed * input.Player.Move_Right.ReadValue<float>() * Time.deltaTime * canRightV);
        transform.Translate(Vector3.left * move_speed * input.Player.Move_Left.ReadValue<float>() * Time.deltaTime * canLeftV);

        if((input.Player.Jump.ReadValue<float>() != 0) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
    		isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canLeft = !canLeft;
            if (canLeftV == 1) { canLeftV = 0; } else { canLeftV = 1; }
            canRight = !canRight;
            if (canRightV == 1) { canRightV = 0; } else { canRightV = 1; }
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            canDown = !canDown;
            if (canDownV == 1) { canDownV = 0; } else { canDownV = 1; }
        }
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            canUp = !canUp;
            if (canUpV == 1) { canUpV = 0; } else { canUpV = 1; }
        }
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