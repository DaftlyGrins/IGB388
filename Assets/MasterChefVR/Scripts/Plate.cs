using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>();
    public Transform newItemLocation;
    public int finalScore;

    public void AddItemToPlate(GameObject item)
    {
        //for (int i = 0; i < 6; i++)
        {
            if (ingredients.Count < 6)
            {
                ingredients.Add(item);
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.GetComponent<Rigidbody>().detectCollisions = false;
                item.transform.SetParent(this.gameObject.transform, true);
                item.transform.localRotation = Quaternion.identity;
                item.transform.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y + item.GetComponent<BoxCollider>().center.y * item.transform.localScale.y, 0.0f);
                newItemLocation.localPosition = new Vector3(0.0f, item.GetComponent<BoxCollider>().size.y * item.transform.localScale.y + newItemLocation.localPosition.y, 0.0f);
                Debug.Log(ingredients.Count);
                return;
            }
        }
        
    }

    public void gradingPlate()
    {
        if(ingredients[0].tag == "TopBun")
        {
            finalScore += 1;
        }
        if (ingredients[1].tag == "LettuceLeaf")
        {
            finalScore += 2;
        }
        if (ingredients[2].tag == "Steak")
        {
            finalScore += 2;
        }
        if (ingredients[3].tag == "CheeseSlice")
        {
            finalScore += 2;
        }
        if (ingredients[4].tag == "TomatoSlice")
        {
            finalScore += 2;
        }
        if (ingredients[5].tag == "BottomBun")
        {
            finalScore += 1;
        }
        if(finalScore > 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            finalScore = 0;
        }
    }

    public void loweringScore()
    {
        finalScore -= 1;
    }
}
