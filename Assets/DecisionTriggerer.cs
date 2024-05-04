using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTriggerer : MonoBehaviour
{
    private bool decision1;
    private bool decision2;
    private bool decision3;
    private bool decision4;
    private bool decision5;
    private bool decision6;
    private bool decision7;
    private bool decision8;
    private bool decision9;
    private bool condition1;
    private bool condition2;
    private bool hasStarted;
    private float countdownTracker;
    private float secondsLeft;
    public GameObject TV;
    private int phase;
    // Start is called before the first frame update
    void Start()
    {
        decision1 = false;
        decision2 = false;
        decision3 = false;
        decision4 = false;
        decision5 = false;
        decision6 = false;
        decision7 = false;
        decision8 = false;
        decision9 = false;
        condition1 = false;
        condition2 = false;
        hasStarted = false;
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(secondsLeft);
        if (hasStarted == true)
        {
            secondsLeft = Time.deltaTime - countdownTracker;
            if (secondsLeft <= 0.5) 
            {
                secondsLeft = 0;
            }
        }
        if (decision1 == true || decision2 == true || decision3 == true && phase == 1)
        {
            hasStarted = false;
            TV.GetComponent<Script>().NewLines();
        }
        if (decision4 == true || decision5 == true && phase == 2)
        {
            hasStarted = false;
            TV.GetComponent<Script>().NewLines2();
        }
        if (decision6 == true || decision7 == true && phase == 3)
        {
            Debug.Log("balls");
            hasStarted = false;
            TV.GetComponent<Script>().NewLines3();
        }
        if(decision8 == true || decision9 == true && phase == 4)
        {
            TV.GetComponent<Script>().Finale();
        }
        if(secondsLeft <= 0 && phase == 4 && decision9 == false)
        {
            decision8 = true;
        }
    }
    public void StartCountdown()
    {
        if (hasStarted == false)
        {
            secondsLeft = 20;
            countdownTracker = Time.deltaTime;
            phase++;
        }
        hasStarted = true;
    }
    public void Decision3()
    {
        if (phase == 1)
        {
            Debug.Log("Decision 3");
            decision3 = true;
        }
   
    }
    public void Decision1()
    {
        Debug.Log("Decision 1");
        if (secondsLeft <= 0.0f && decision3 == false && phase == 1)
        {
            decision1 = true;
        }
    }
    public void Decision2()
    {
        Debug.Log("Decision 2");
        if (secondsLeft <= 0.0f && decision3 == false && phase == 1)
        {
            decision2 = true;
        }
    }
    public void Decision4()
    {
        Debug.Log("Decision 4");
        if (secondsLeft <= 0.0f && phase == 2)
        {
            decision4 = true;
        }
    }
    public void Decision5()
    {
        Debug.Log("Decision 5");
        if (secondsLeft <= 0.0f && phase == 2)
        {
            decision5 = true;
        }
    }
    public void Decision6()
    {
        Debug.Log("Decision 6");
        if (secondsLeft <= 0.0f && phase == 3)
        {
            decision6 = true;
        }
    }
    public void Decision7()
    {
        Debug.Log("Decision 7");
        if (secondsLeft <= 0.0f && phase == 3)
        {
            decision7 = true;
        }
    }
    public void Condition1()
    {
        condition1 = true;
    }
    public void NotLeft()
    {
        condition1 = false;
    }
    public void Condition2()
    {
        if(condition1 == true)
        {
            condition2 = true;
        }
    }
    public void FinalDecision()
    {
        if(condition1 == true && condition2 == true)
        {
            decision9 = true;
        }
    }
    public void isMaximum()
    {
        Debug.Log("isMaximised");
    }
    public void isMinimum()
    {
        Debug.Log("isMinimised");
    }
}
