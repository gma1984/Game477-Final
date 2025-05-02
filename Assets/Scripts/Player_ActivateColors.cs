using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using State = ColorState;

enum ColorState { None, Red, Green, Blue, Yellow, Magenta, Cyan, White }

public class Player_ActivateColors : MonoBehaviour
{
    public GameObject redSignal;
    public GameObject greenSignal;
    public GameObject blueSignal;
    public GameObject yellowSignal;
    public GameObject magentaSignal;
    public GameObject cyanSignal;
    public GameObject whiteSignal;
    public bool red = false;
    public bool green = false;
    public bool blue = false;
    public bool jackOne = false;
    public bool jackTwo = false;
    public bool jackThree = false;
    private State State;
    private Dictionary<State, Action> stateEnterMethods;
    private Dictionary<State, Action> stateStayMethods;
    // Start is called before the first frame update
    void Start()
    {
        stateEnterMethods = new() {
            [State.None] = StateEnter_None,
            [State.Red] = StateEnter_Red,
            [State.Green] = StateEnter_Green,
            [State.Blue] = StateEnter_Blue,
            [State.Yellow] = StateEnter_Yellow,
            [State.Magenta] = StateEnter_Magenta,
            [State.Cyan] = StateEnter_Cyan,
            [State.White] = StateEnter_White,
        };
        stateStayMethods = new() {
            [State.None] = StateStay_None,
            [State.Red] = StateStay_Red,
            [State.Green] = StateStay_Green,
            [State.Blue] = StateStay_Blue,
            [State.Yellow] = StateStay_Yellow,
            [State.Magenta] = StateStay_Magenta,
            [State.Cyan] = StateStay_Cyan,
            [State.White] = StateStay_White,
        };
        State = State.None;
    }

    // Update is called once per frame
    void Update()
    {
        stateStayMethods[State]();
    }

    private void ChangeState(State newState) {
        if (State != newState) {
            State = newState;
            stateEnterMethods[newState]();
        }
    }

    #region State Methods

    #region State Enter Methods
    private void StateEnter_None()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Red()
    {
        redSignal.SetActive(true);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Green()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(true);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Blue()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(true);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Yellow()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(true);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Magenta()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(true);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_Cyan()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(true);
        whiteSignal.SetActive(false);
    }
    private void StateEnter_White()
    {
        redSignal.SetActive(false);
        greenSignal.SetActive(false);
        blueSignal.SetActive(false);
        yellowSignal.SetActive(false);
        magentaSignal.SetActive(false);
        cyanSignal.SetActive(false);
        whiteSignal.SetActive(true);
    }
    #endregion

    #region State Stay Methods
    private void StateStay_None()
    {
        if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha1)) && jackTwo)
        {
            ChangeState(State.Yellow);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha2)) && jackTwo)
        {
            ChangeState(State.Magenta);
        }
        else if (((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha3)) && jackTwo)
        {
            ChangeState(State.Cyan);
        }
        else if (Input.GetKeyDown(KeyCode.R) && red && jackOne)
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.G) && green && jackOne)
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.B) && blue && jackOne)
        {
            ChangeState(State.Blue);
        }
    }
    private void StateStay_Red()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) && jackTwo)
        {
            ChangeState(State.Cyan);
        } 
        else if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha3)) && jackTwo)
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Alpha1)) && jackTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Alpha2)) && jackTwo)
        {
            ChangeState(State.Magenta);
        }
        else if (Input.GetKeyDown(KeyCode.G) && green)
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.B) && blue)
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_Green()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) && jackTwo)
        {
            ChangeState(State.Magenta);
        } 
        else if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha2)) && jackTwo)
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Alpha1)) && jackTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Alpha3)) && jackTwo)
        {
            ChangeState(State.Cyan);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.B) && blue)
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_Blue()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) && jackTwo)
        {
            ChangeState(State.Yellow);
        } 
        else if (Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.B) && Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha1)) && jackTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Alpha2)) && jackTwo)
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Alpha3)) && jackTwo)
        {
            ChangeState(State.Cyan);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_Yellow()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)))
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_Magenta()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) )
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_Cyan()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G)) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Alpha4)) && jackThree)
        {
            ChangeState(State.White);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    private void StateStay_White()
    {
        if ((Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B)) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeState(State.None);
        }
        else if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(State.Blue);
        }
        else if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Green);
        }
        else if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.B))
        {
            ChangeState(State.Red);
        }
        else if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(State.Yellow);
        }
        else if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(State.Magenta);
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(State.Cyan);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(State.None);
        }
    }
    #endregion

    #endregion
}