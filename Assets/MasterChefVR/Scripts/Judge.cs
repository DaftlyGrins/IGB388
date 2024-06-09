using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [Header("Starting Information")]
    [SerializeField] private Transform mainPos;
    [SerializeField] private Transform sidePos;
    [SerializeField] private float walkSpeed;
    private bool movingToMainPos = false;
    private bool movingToSidePos = true;
    [SerializeField] private float delayWalkoutTime;
    [SerializeField] private bool walksLeftSide;

    [Header("Componenet Information")]
    private Rigidbody rb;
    private Animator anim;

    [Header("Dialogue Information")]
    private AudioSource audioSource;
    private Dialogue dialogueManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        dialogueManager = GameManager.Instance.dialogueManager.GetComponent<Dialogue>();
        Invoke("DelayWalkoutTime", delayWalkoutTime);
    }

    void Update(){
        // Play talking animation when audio clip is playing
        if (audioSource.isPlaying) anim.SetBool("Talking", true);
        else anim.SetBool("Talking", false);
    }

    void FixedUpdate()
    {
        if (movingToMainPos){MoveJudge();}
        transform.LookAt(GameManager.Instance.player.transform);
        transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, 0.0f);
    }

    void MoveJudge()
    {
        Vector3 target = mainPos.position;
        if (movingToSidePos)
        {
            target = sidePos.position;
        }

        Vector3 direction = (target - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target);
        rb.MovePosition(transform.position + direction * distance * walkSpeed * Time.fixedDeltaTime);

        if (distance < 0.2 && !movingToSidePos)
        {
            movingToMainPos = false;
            anim.SetBool("Walking", false);
        }
        
        if (distance < 0.2f && movingToSidePos)
        { 
            movingToSidePos = false;
            float rotation = 90.0f;
            if (walksLeftSide) { rotation = -90.0f;}
            transform.Rotate(0f, rotation, 0f);
        }

        
    }

    void DelayWalkoutTime()
    {
        movingToMainPos = true;
    }
}
