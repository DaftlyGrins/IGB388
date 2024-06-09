using System.Collections;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

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
  public Transform judgePlatingPosition;
  public float[] judgingLevels = new float[] {5f, 10f, 15f, 20f};
  private int currentJudgeIndex = 0;
  private string plateRating = "";
  public GameObject cameraOVR;

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

  public void Judging(float plateGrade){
    plateRating = "";

    if (plateGrade > judgingLevels[3])
    {
      plateRating = "Best";
    }
    else if (plateGrade > judgingLevels[2])
    {
      plateRating = "Good";
    }
    else if (plateGrade > judgingLevels[1])
    {
      plateRating = "Average";
    }
    else {
      plateRating = "Bad";
    }

    GiveReview(plateRating, currentJudgeIndex);
    Invoke("NextJudge", 7.0f);
    Invoke("NextJudge", 14.0f);
    Invoke("RestartScene", 35.0f);
  }

  private void NextJudge()
  {
    GiveReview(plateRating, currentJudgeIndex);
  }

  private void GiveReview(string plateRating, int judgeIndex){
    if (plateRating == "Best")
    {
      dialogueManager.GetComponent<Dialogue>().PlayClip(judges[judgeIndex].gameObject, 4);
    }
    else if (plateRating == "Good")
    {
      dialogueManager.GetComponent<Dialogue>().PlayClip(judges[judgeIndex].gameObject, 3);
    }
    else if (plateRating == "Average")
    {
      dialogueManager.GetComponent<Dialogue>().PlayClip(judges[judgeIndex].gameObject, 2);
    }
    else if (plateRating == "Bad")
    {
      dialogueManager.GetComponent<Dialogue>().PlayClip(judges[judgeIndex].gameObject, 1);
    }
    currentJudgeIndex += 1;
    if (currentJudgeIndex > 2) currentJudgeIndex = 0;
  }

  private void RestartScene(){
    SceneManager.LoadScene(0);
  }

  // Add any GameManager-related initialization or cleanup here
}
