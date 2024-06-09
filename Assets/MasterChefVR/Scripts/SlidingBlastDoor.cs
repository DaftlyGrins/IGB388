
using System.Collections;
using UnityEngine;

public class SlidingBlastDoor : MonoBehaviour
{
  public float speed = 1.0f;
  public AudioSource[] audioSources;
  public GameObject display;

  private float targetY = -2.49f;
  private Vector3 targetPosition;
  [SerializeField] private bool isOpen = false;
  private bool isConfirming = false;

  void Start()
  {
    targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
  }

  void Update()
  {
    if (!isOpen) return;

    GetComponentInParent<Transform>().position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    if (transform.position.y == targetY) isOpen = false;
  }

  public void Open()
  {
    audioSources[0].Play();
    StartCoroutine(WaitToOpen());
  }

  IEnumerator WaitToOpen()
  {
    yield return new WaitForSeconds(5.0f);
    
    isConfirming = true;
    display.SetActive(true);
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player") || !isConfirming) return;

    audioSources[1].Play();
    GameManager.Instance.dialogueManager.GetComponent<Dialogue>().PlayClip(GameManager.Instance.judges[0].gameObject, 0); // Play the gravity inversion hint
    isOpen = true;
    isConfirming = false;
    display.GetComponent<Collider>().enabled = false;
    GetComponent<InitiateGravityInversion>().InitiateInversion();
  }
}
