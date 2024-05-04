using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;
    public GameObject TV;
    public AudioClip clip1;
    public AudioClip clip2;
    private bool active;
    private bool hasFinished;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        hasFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasFinished == true && !source2.isPlaying)
        {
            SwitchDeactive();
        }
    }

    public void SwitchActive()
    {
        source.clip = clip2;
        active = true;
        source.Play();
    }

    public void SwitchDeactive()
    {
        source.clip = clip1;
        active = false;
        TV.GetComponent<Script>().mercyCryDone();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(active == false)
        {
            SoundOnZone zone = other.GetComponent<SoundOnZone>();
            if (zone == null) return;
            source.Play();
        }
        else if(active == true)
        {
            SoundOnZone zone = other.GetComponent<SoundOnZone>();
            if (zone == null) return;
            source.Stop();
            source2.Play();
            hasFinished = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(active == false)
        {
            SoundOnZone zone = other.GetComponent<SoundOnZone>();
            if (zone == null) return;
            source.Stop();
        }
        else if(active == true)
        {
            SoundOnZone zone = other.GetComponent<SoundOnZone>();
            if (zone == null) return;
            source2.Pause();
            source.Play();
            hasFinished = false;
        }
    }
}
