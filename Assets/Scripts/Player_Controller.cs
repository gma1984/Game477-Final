using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float move_speed = 10;
    private InputSystem_Actions input;
    // Start is called before the first frame update
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * move_speed * input.Player.Move_Right.ReadValue<float>() * Time.deltaTime);
        transform.Translate(Vector3.left * move_speed * input.Player.Move_Left.ReadValue<float>() * Time.deltaTime);
    }
}