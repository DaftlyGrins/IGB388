using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDs : MonoBehaviour
{
    public Material firstSprite;
    public Material secondSprite;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = firstSprite;
    }

    // Update is called once per frame
    public void Switch()
    {
        // firstImage = firstSprite;
        this.gameObject.GetComponent<MeshRenderer>().material = secondSprite;
    }
    public void SwitchBack()
    {
        // firstImage = firstSprite;
        this.gameObject.GetComponent<MeshRenderer>().material = firstSprite;
    }
}
