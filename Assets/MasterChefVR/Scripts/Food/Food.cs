using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float cookingInterval = 10f;
    private float timeCooked;
    public Material raw;
    public Material underCooked;
    public Material cooked;
    public Material overCooked;
    public Material burnt;

    void Start()
    {
        timeCooked = 0f;
        this.GetComponent<Renderer>().material = raw;
    }
    
    public void Cook(float cookingTime)
    {
        timeCooked += cookingTime;
        if (timeCooked >= 1 * cookingInterval)
        {
            this.GetComponent<Renderer>().material = underCooked;
        }
        if (timeCooked >= 2 * cookingInterval)
        {
            this.GetComponent<Renderer>().material = cooked;
        }
        if (timeCooked >= 3 * cookingInterval)
        {
            this.GetComponent<Renderer>().material = overCooked;
        }
        if (timeCooked >= 4 * cookingInterval)
        {
            this.GetComponent<Renderer>().material = burnt;
        }
    }
}
