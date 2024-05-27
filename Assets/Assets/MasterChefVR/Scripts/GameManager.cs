using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

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
    }

    // Add any GameManager-related initialization or cleanup here
}
