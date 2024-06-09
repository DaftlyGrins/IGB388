using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;
  public GameObject wellGiantLevel = null;
  public GameObject player;
  public GameObject[] lights;
  public GameObject logo;
  public GameObject dialogueManager;
  public GameObject mysteryBox;
  public Clock clock;
  public Judge[] judges; 

  public static GameManager Instance
  {
    get
    {
      if (_instance == null)
      {
        // Search for an existing GameManager instance in the scene
        _instance = FindObjectOfType<GameManager>();

        // If no instance exists, create a new one
        if (_instance == null)
        {
          GameObject obj = new GameObject("GameManager");
          _instance = obj.AddComponent<GameManager>();
        }
      }
      return _instance;
    }
  }

  // Add any GameManager-related variables and methods here

  void Awake()
  {
    // Ensure there is only one instance of GameManager in the scene
    if (_instance == null)
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        // If another GameManager already exists, destroy this one
        Destroy(gameObject);
    }

    StartLighting();
  }

  private void StartLighting()
  {
    StartCoroutine(LightSequence());
  }

  private IEnumerator LightSequence()
  {
    yield return new WaitForSeconds(5);

    dialogueManager.GetComponent<Dialogue>().PlayIntroduction();
    logo.GetComponent<SpaceLight>().LightOn();
    logo.GetComponentInChildren<Light>().enabled = true;

    yield return new WaitForSeconds(18);

    LightOn(0);
    mysteryBox.GetComponent<CustomGrabbable>().enabled = true;
    mysteryBox.GetComponent<GrabOutlineController>().enabled = true;
  }

  private void LightOn(int index)
  {
    SpaceLight lightScript = lights[index].GetComponent<SpaceLight>();

    if (lightScript != null)
    {
      lightScript.LightOn();
    } else {
      lights[index].GetComponent<Light>().enabled = true;
    }
  }

  public Judge ReturnRandomJudge(){
    System.Random random = new System.Random();
    return judges[random.Next(judges.Length)];
  }

  // Add any GameManager-related initialization or cleanup here
}
