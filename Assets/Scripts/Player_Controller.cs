using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float move_speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*var input = Game.Input.Player;

        transform.Translate(Vector3.right * move_speed * input.MoveRight.ReadValue<float>() * Time.deltaTime);
        transform.Translate(Vector3.left * move_speed * input.MoveLeft.ReadValue<float>() * Time.deltaTime);*/
    }
}