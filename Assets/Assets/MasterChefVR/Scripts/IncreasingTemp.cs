using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IncreasingTemp : MonoBehaviour
{
    private int countdown;
    public float countdownFrom;
    private float storedCountdown;
    public TMP_Text counting;
    // Start is called before the first frame update
    void Start()
    {
        storedCountdown = countdownFrom;
    }

    // Update is called once per frame
    void Update()
    {
        countdownFrom -= Time.deltaTime;
        countdown = Convert.ToInt32(countdownFrom);
        counting.text = countdown.ToString();

        if(countdownFrom <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void heatReset()
    {
        countdownFrom = storedCountdown;
    }
}
