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
    public GameObject redIndicator;
    public GameObject greenIndicator;
    public GameObject blueIndicator;
    public GameObject yellowIndicator;
    public GameObject magentaIndicator;
    public GameObject cyanIndicator;
    public GameObject whiteIndicator;
    public bool red = false;
    public bool green = false;
    public bool blue = false;
    public bool portOne = false;
    public bool portTwo = false;
    public bool portThree = false;
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

        redIndicator.SetActive(false);
        greenIndicator.SetActive(false);
        blueIndicator.SetActive(false);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(true);
        greenIndicator.SetActive(false);
        blueIndicator.SetActive(false);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(false);
        greenIndicator.SetActive(true);
        blueIndicator.SetActive(false);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(false);
        greenIndicator.SetActive(false);
        blueIndicator.SetActive(true);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(true);
        greenIndicator.SetActive(true);
        blueIndicator.SetActive(false);
        yellowIndicator.SetActive(true);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(true);
        greenIndicator.SetActive(false);
        blueIndicator.SetActive(true);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(true);
        cyanIndicator.SetActive(false);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(false);
        greenIndicator.SetActive(true);
        blueIndicator.SetActive(true);
        yellowIndicator.SetActive(false);
        magentaIndicator.SetActive(false);
        cyanIndicator.SetActive(true);
        whiteIndicator.SetActive(false);
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

        redIndicator.SetActive(true);
        greenIndicator.SetActive(true);
        blueIndicator.SetActive(true);
        yellowIndicator.SetActive(true);
        magentaIndicator.SetActive(true);
        cyanIndicator.SetActive(true);
        whiteIndicator.SetActive(true);
    }
    #endregion

    #region State Stay Methods
    private void StateStay_None()
    {
        if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portThree && red && green && blue)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8))) && portTwo && red && green)
        {
            ChangeState(State.Yellow);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo && red && blue)
        {
            ChangeState(State.Magenta);
        }
        else if (((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo && green && blue)
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && red && portOne)
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && green && portOne)
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && blue && portOne)
        {
            ChangeState(State.Blue);
        }
    }
    private void StateStay_Red()
    {
        if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo)
        {
            ChangeState(State.Cyan);
        } 
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && green)
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && blue)
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo)
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && portTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && portTwo)
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && green)
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && blue)
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
        if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo)
        {
            ChangeState(State.Magenta);
        } 
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && blue)
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo)
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && portTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && portTwo)
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && blue)
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
        if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9))) && portTwo)
        {
            ChangeState(State.Yellow);
        } 
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.None);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8))) && portThree)
        {
            ChangeState(State.White);
        }
        else if (((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8))) && portTwo)
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && portTwo)
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && portTwo)
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
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
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)) && portThree)
        {
            ChangeState(State.White);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
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
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Cyan);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && portThree)
        {
            ChangeState(State.White);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
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
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && portThree)
        {
            ChangeState(State.White);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
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
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.None);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Blue);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Green);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)) && (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Red);
        }
        else if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad9)))
        {
            ChangeState(State.Yellow);
        }
        else if ((Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad8)))
        {
            ChangeState(State.Magenta);
        }
        else if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad7)))
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