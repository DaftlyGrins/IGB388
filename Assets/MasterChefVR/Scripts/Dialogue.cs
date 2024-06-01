using UnityEngine;

public class Dialogue : MonoBehaviour
{
  public GameObject introductionParent;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void PlayIntroduction()
  {
    introductionParent.GetComponent<AudioSource>().Play();
  }
}
