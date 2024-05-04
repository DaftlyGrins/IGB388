using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{

    public Sprite firstSprite;
    public Sprite secondSprite;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = firstSprite;
    }



    // Update is called once per frame
    public void Switch()
    {
        // firstImage = firstSprite;
        this.gameObject.GetComponent<Image>().sprite = secondSprite;
    }
}
