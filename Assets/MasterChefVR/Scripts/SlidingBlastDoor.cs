
using UnityEngine;

public class SlidingBlastDoor : MonoBehaviour
{
  public float speed = 1.0f;
  public AudioSource[] audioSources;
  public GameObject display;

  private float targetY = -2.49f;
  private Vector3 targetPosition;
  private bool isOpen = false;
  private bool isConfirming = false;

  void Start()
  {
    targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
  }

  void Update()
  {
    if (!isOpen) return;

    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
  }

  public void Open()
  {
    isConfirming = true;
    audioSources[0].Play();
    display.SetActive(true);
  }

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player") || !isConfirming) return;

    audioSources[1].Play();
    isOpen = true;
    isConfirming = false;
    display.GetComponent<Collider>().enabled = false;
  }
}
