using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager : MonoBehaviour {

    public enum ButtonTriggered { ButtonA, ButtonB, ButtonX, ButtonY};
    public ButtonTriggered button;   
    public float timeInLess;
    private int buttonCount = 0;
    private string joystickName;

    //EVENT CONCERNED
    public EventManager eventObject;
    private float timer;

    private void Start()
    {
        timer = eventObject.minuteur;    
    }

    private void Awake()
    {
        switch (button)
        {
            case ButtonTriggered.ButtonA:
                joystickName = "joystick button 0";
                break;
            case ButtonTriggered.ButtonB:
                joystickName = "joystick button 1";
                break;
            case ButtonTriggered.ButtonX:
                joystickName = "joystick button 2";
                break;
            case ButtonTriggered.ButtonY:
                joystickName = "joystick button 3";
                break;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(joystickName))
        {
            buttonCount++;
            timer -= timeInLess;
        }
    }
}

