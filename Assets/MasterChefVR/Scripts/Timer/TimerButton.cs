using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerButton : MonoBehaviour
{
    // Information about button movement
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    public bool buttonBeingPushed = false;
    public bool hasBeenPressed = false;

    // Information about timer
    public Timer timer;

    // Button information
    public string buttonName;
    public int buttonValue;

    // Other Button information
    public TimerButton[] otherButtons;

    // Release buffere bug fix
    public float bufferTime;
    private bool timerHeld = false;
    private bool isInBufferWindow = false;

    void Update() {

        // Move button when being pushed or not
        if (buttonBeingPushed) {transform.position = Vector3.Lerp(transform.position, endPoint.position, Time.deltaTime * moveSpeed);}
        else{transform.position = Vector3.Lerp(transform.position, startPoint.position, Time.deltaTime * moveSpeed);}

        // If button is pressed all the way down do something
        if (transform.position.y <= endPoint.position.y + 0.001f && ! hasBeenPressed && buttonBeingPushed){ButtonPressed();}

        // Allow button to be released all the way
        if (transform.position.y >= startPoint.position.y - 0.001f && hasBeenPressed) {hasBeenPressed = false;}

        // Check to see if timer is held
        if (timer.grabbable.grabbedBy != null && !timerHeld) // Timer is getting grabbed this update
        {
            timerHeld = true;
        }

        if(timerHeld && timer.grabbable.grabbedBy == null) // Timer is getting released this update
        {
            isInBufferWindow = true;
            Invoke("DisableBufferWindow", bufferTime);
        }
    }

    void DisableBufferWindow() {isInBufferWindow = false;}

    void ButtonPressed()
    {
        hasBeenPressed = true;
        if (this.buttonName == "Seconds") {timer.AddSeconds(buttonValue);}
        else if(this.buttonName == "Minutes") {timer.AddMinutes(buttonValue);}
        else {timer.StartTimer();}
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "RightGrabber" || other.gameObject.name == "LeftGrabber")
        {
            if (!otherButtons[0].buttonBeingPushed && !otherButtons[1].buttonBeingPushed && !isInBufferWindow)
            {
                buttonBeingPushed = true;
            }
        }      
    }

    void OnTriggerExit(Collider other) {buttonBeingPushed = false;}
}
