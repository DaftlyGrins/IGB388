using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameObject meal;
    public GameObject noGameOver;
    public bool mealDelivered;
    public int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plate")
        {
            meal = other.transform.gameObject;
            if (meal.GetComponent<Plate>().ingredients.Count == 6)
            {
                //noGameOver.GetComponent<IncreasingTemp>().enabled = false;
                meal.GetComponent<Plate>().gradingPlate();
                finalScore = meal.GetComponent<Plate>().finalScore;
                mealDelivered = true;
                Debug.Log("yippee");
            }
            else
            {
                Debug.Log("swagmode");
            }
        }

    }
}
