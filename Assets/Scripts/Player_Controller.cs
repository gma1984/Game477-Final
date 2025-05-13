using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float move_speed = 10;
    private InputSystem_Actions input;
    public Vector3 jump;
    public float jumpForce;
    public bool isGrounded;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Player_ActivateColors ColorScript;
    public Transform groundSensor;
    public Transform groundSensor2;
    public Transform groundSensor3;
    public LayerMask groundCheckLayerMask;
    public float groundCheckDistance;
    public int playerHealth = 3;
    public bool iFrames = false;
    private bool isJumping = false;
    private int dir = 0;
    private Rigidbody rigid;
    public GameObject[] hearts;

    // coyote time and jump compensation
    public float EdgeCompensation;


    // Start is called before the first frame update
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
        sr = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 6.0f, 0.0f);
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth >= 3)
        {
            playerHealth = 3;
        }
        if (playerHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (playerHealth <= 2)
                {
                    hearts[playerHealth].SetActive(true);
                }
                playerHealth += 1;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerHealth -= 1;
                hearts[playerHealth].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                input.Disable();
                Score.Instance.timerStop();
                Score.Instance.addTimeScore();
                SceneManager.LoadScene("Game Win");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                sr.flipX = true;
                dir = -1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                sr.flipX = false;
                dir = 1;
            }
            isGrounded = RaycastFromSensor(groundSensor, groundSensor2, groundSensor3);
            VelocityX(dir, isGrounded);

            if (isGrounded)
            {
                EdgeCompensation = 0.2f;
            }
            else
            {
                EdgeCompensation -= Time.deltaTime;
            }




            if ((input.Player.Jump.ReadValue<float>() != 0) && EdgeCompensation > 0f)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Invoke("NoJump", 0.1f);
                //rb.AddForce(Vector3.up * jumpForce);
            }


            if ((input.Player.Jump.ReadValue<float>() == 0) && rb.velocity.y > 0f && !isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.95f);
                EdgeCompensation = EdgeCompensation -= Time.deltaTime;

            }
        }
        else if (playerHealth <= 0)
        {
            playerHealth = 0;
            input.Disable();
            SceneManager.LoadScene("Game Over");
        }
    }

    private void VelocityX(int direction, bool grounded)
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, 120f * Time.deltaTime), rb.velocity.y);
        }
        else
        {
            if (grounded == true)
            {
                rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, move_speed * direction, 75f * Time.deltaTime), rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, move_speed * 0.98f * direction, 75f * Time.deltaTime), rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("BasicEnemy") && !iFrames) || (collision.gameObject.CompareTag("Kill Barrier") && !iFrames))
        {
            playerHealth -= 1;
            hearts[playerHealth].SetActive(false);
            iFrames = true;
            Invoke("RemoveIFrames", 1.5f);
        }
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
            ColorScript.portOne = true;
            Destroy(collision.gameObject);
            Score.Instance.AddToScore(2500f);
        }
        if (collision.gameObject.CompareTag("PlugG"))
        {
            ColorScript.green = true;
            Destroy(collision.gameObject);
            Score.Instance.AddToScore(2500f);
        }
        if (collision.gameObject.CompareTag("PlugB"))
        {
            ColorScript.blue = true;
            Destroy(collision.gameObject);
            Score.Instance.AddToScore(2500f);
        }
        if (collision.gameObject.CompareTag("Port2"))
        {
            ColorScript.portTwo = true;
            Destroy(collision.gameObject);
            Score.Instance.AddToScore(2500f);
        }
        if (collision.gameObject.CompareTag("Port3"))
        {
            ColorScript.portThree = true;
            Destroy(collision.gameObject);
            Score.Instance.AddToScore(2500f);
        }
        if (collision.gameObject.CompareTag("HealHeart") && playerHealth <= 2)
        {
            Destroy(collision.gameObject);
            if (playerHealth <= 2)
            {
                hearts[playerHealth].SetActive(true);
            }
            playerHealth += 1;
        }
        if (collision.gameObject.CompareTag("WinZone"))
        {
            Score.Instance.AddToScore(15000f);
            Score.Instance.timerStop();
            Score.Instance.addTimeScore();
            SceneManager.LoadScene("Game Win");
        }
    }

    public bool RaycastFromSensor(Transform groundSensor, Transform groundSensorTwo, Transform groundSensorThree)
    {
        RaycastHit2D hitOne;
        RaycastHit2D hitTwo;
        RaycastHit2D hitThree;
        hitOne = Physics2D.Raycast(groundSensor.position, groundSensor.forward, groundCheckDistance, groundCheckLayerMask);
        hitTwo = Physics2D.Raycast(groundSensorTwo.position, groundSensorTwo.forward, groundCheckDistance, groundCheckLayerMask);
        hitThree = Physics2D.Raycast(groundSensorThree.position, groundSensorThree.forward, groundCheckDistance, groundCheckLayerMask);
        if (hitOne.collider != null || hitTwo.collider != null || hitThree.collider != null)
        {
            return true;
        }
        return false;
    }

    public void ColorHandler()
    {
        //fill later
    }

    private void RemoveIFrames()
    {
        iFrames = false;
    }

    private void NoJump()
    {
        isJumping = false;
    }
}