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
    public Timer     timer;

    // Button information
    public string buttonName;
    public int buttonValue;

    void Update() {

        // Move button when being pushed or not
        if (buttonBeingPushed) {transform.position = Vector3.Lerp(transform.position, endPoint.position, Time.deltaTime * moveSpeed);}
        else{transform.position = Vector3.Lerp(transform.position, startPoint.position, Time.deltaTime * moveSpeed);}

        // If button is pressed all the way down do something
        if (transform.position.y <= endPoint.position.y + 0.001f && ! hasBeenPressed){ButtonPressed();}

        // Allow button to be released all the way
        if (transform.position.y >= startPoint.position.y - 0.001f && hasBeenPressed) {hasBeenPressed = false;}
    }

    void ButtonPressed()
    {
        hasBeenPressed = true;
        if (this.buttonName == "Seconds") {timer.AddSeconds(buttonValue);}
        else if(this.buttonName == "Minutes") {timer.AddMinutes(buttonValue);}
        else {timer.StartTimer();}
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "RightGrabber" || other.gameObject.name == "LeftGrabber"){buttonBeingPushed = true;}        
    }

    void OnTriggerExit(Collider other) {buttonBeingPushed = false;}
}
