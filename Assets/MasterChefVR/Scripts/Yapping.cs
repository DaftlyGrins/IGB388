using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yapping : MonoBehaviour
{
    public AudioSource dialogue;
    public GameObject JudgesDesk;
    public GameObject[] otherDialogue;
    public AudioClip[] script;
    public bool isTalking;
    private int line;
    // Start is called before the first frame update
    void Start()
    {
        line = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(otherDialogue[0].GetComponent<Yapping>().isTalking == false && otherDialogue[1].GetComponent<Yapping>().isTalking == false)
        {
            if (line < 2)
            {
                dialogue.clip = script[line];
                dialogue.Play();
                if (!dialogue.isPlaying)
                {
                    line += 1;
                    isTalking = false;
                    otherDialogue[0].GetComponent<Yapping>().isTalking = true;
                }
            }
            else if (JudgesDesk.GetComponent<EndLevel>().mealDelivered == true)
            {
                if (otherDialogue[0].GetComponent<Yapping>().isTalking == false && otherDialogue[1].GetComponent<Yapping>().isTalking == false)
                {
                    if(JudgesDesk.GetComponent<EndLevel>().finalScore < 4)
                    {
                        line = 2;
                        dialogue.clip = script[line];
                        dialogue.Play();
                        if (!dialogue.isPlaying)
                        {
                            isTalking = false;
                            otherDialogue[0].GetComponent<Yapping>().isTalking = true;
                        }
                    }
                    else if (JudgesDesk.GetComponent<EndLevel>().finalScore >= 4 && JudgesDesk.GetComponent<EndLevel>().finalScore < 7)
                    {
                        line = 3;
                        dialogue.clip = script[line];
                        dialogue.Play();
                        if (!dialogue.isPlaying)
                        {
                            isTalking = false;
                            otherDialogue[0].GetComponent<Yapping>().isTalking = true;
                        }
                    }
                    else if (JudgesDesk.GetComponent<EndLevel>().finalScore >= 7 && JudgesDesk.GetComponent<EndLevel>().finalScore < 10)
                    {
                        line = 4;
                        dialogue.clip = script[line];
                        dialogue.Play();
                        if (!dialogue.isPlaying)
                        {
                            isTalking = false;
                            otherDialogue[0].GetComponent<Yapping>().isTalking = true;
                        }
                    }
                    else if (JudgesDesk.GetComponent<EndLevel>().finalScore >= 10)
                    {
                        line = 5;
                        dialogue.clip = script[line];
                        dialogue.Play();
                        if (!dialogue.isPlaying)
                        {
                            isTalking = false;
                            otherDialogue[0].GetComponent<Yapping>().isTalking = true;
                        }
                    }
                }
            }
        }
    }
}
