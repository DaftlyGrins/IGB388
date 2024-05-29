using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;
  public GameObject wellGiantLevel = null;
  public GameObject[] lights;
  public GameObject[] logos;

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

    foreach (GameObject logo in logos)
    {
      logo.GetComponent<SpaceLight>().LightOn();
      logo.GetComponentInChildren<Light>().enabled = true;
    }

    yield return new WaitForSeconds(5);



    foreach(GameObject light in lights)
    {
      SpaceLight lightScript = light.GetComponent<SpaceLight>();

      if (lightScript != null)
      {
        lightScript.LightOn();
      } else {
        light.GetComponent<Light>().enabled = true;
      }
    }
  }

    // Add any GameManager-related initialization or cleanup here
}
