using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBlastDoor : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonPushed()
    {
        anim.Play("BlastDoorMoving");
    }
}
