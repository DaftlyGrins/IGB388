using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotableItem : MonoBehaviour
{
    private bool inProximetyOfPot = false;
    public string inPotName;
    private Pot pot;


    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Pot"){
            inProximetyOfPot = true;
            pot = other.gameObject.GetComponent<Pot>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Pot"){
            inProximetyOfPot = false;
        }
    }

    public void GrabEndFunction()
    {
        if (inProximetyOfPot)
        {
            pot.EnableFood(inPotName);
            Destroy(this.gameObject);
        }
    }
}
