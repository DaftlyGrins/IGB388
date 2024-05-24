using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRender : MonoBehaviour
{
    public Material[] material;
    private int x;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    public void changeRendOff()
    {
        x = 0;
    }
    
    public void changeRendOn()
    {
        x = 1;
    }
}
