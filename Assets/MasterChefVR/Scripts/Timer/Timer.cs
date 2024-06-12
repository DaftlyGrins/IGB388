using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Information about timer
    public TMP_Text timerText;
    public int timerSeconds = 0;
    public int timerMinutes = 0;
    public bool countingDown;

    public AudioSource buzzer;
    public CustomGrabbable grabbable;

    void Update()
    {
        timerText.text = timerMinutes + " : " + timerSeconds.ToString("00");
    }

    public void AddSeconds(int seconds)
    {
        timerSeconds += seconds;
        if (timerSeconds >= 60)
        {
            timerMinutes += 1;
            timerSeconds -= 60;
        }
    }

    public void AddMinutes(int minutes)
    {
        timerMinutes += minutes;
    }

    public void StartTimer()
    {
        if (countingDown)
        {
            ResetTimer();
            return;
        }
        countingDown = true;
        InvokeRepeating("CountDown", 0.0f, 1.0f);
    }

    public void ResetTimer()
    {
        timerSeconds = 0;
        timerMinutes = 0;
        if (countingDown) buzzer.Play(0);

        countingDown = false;

        if (grabbable.grabbedBy == CustomGrabber.leftHandGrabber)
        {
            SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.LTouch);
        }
        else if (grabbable.grabbedBy == CustomGrabber.rightHandGrabber)
        {
            SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.RTouch);
        }
    }

    void CountDown()
    {
        if (timerSeconds == 0)
        {
            if (timerMinutes == 0)
            {
                CancelInvoke("CountDown");
                countingDown = false;
            }
            else
            {
                timerMinutes -= 1;
                timerSeconds = 59;
            }
        }
        else
        {
            timerSeconds -= 1;
        }

        if (timerMinutes == 0 && timerSeconds < 4 && timerSeconds > 0)
        {
            buzzer.Play(0);
            if (grabbable.grabbedBy == CustomGrabber.leftHandGrabber)
            {
                SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.LTouch);
            }
            else if (grabbable.grabbedBy == CustomGrabber.rightHandGrabber)
            {
                SimpleHapticVibrationManager.VibrateController(0.3f, 1.0f, OVRInput.Controller.RTouch);
            }
        }

        if (timerMinutes == 0 && timerSeconds == 0)
        {
            buzzer.Play(0);
            if (grabbable.grabbedBy == CustomGrabber.leftHandGrabber)
            {
                SimpleHapticVibrationManager.VibrateController(3.0f, 1.0f, OVRInput.Controller.LTouch);
            }
            else if (grabbable.grabbedBy == CustomGrabber.rightHandGrabber)
            {
                SimpleHapticVibrationManager.VibrateController(3.0f, 1.0f, OVRInput.Controller.RTouch);
            }
        }
    }
}
