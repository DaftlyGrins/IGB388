using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>();
    public Transform newItemLocation;
    public int finalScore;
    public GameObject GrabPosition;
    public List<GameObject> childGrabPositions = new List<GameObject>();

    public void AddItemToPlate(GameObject item)
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i] == null)
            {
                ingredients.Add(item);
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.GetComponent<Rigidbody>().detectCollisions = false;
                item.transform.SetParent(this.gameObject.transform, true);
                item.transform.localRotation = Quaternion.identity;
                item.transform.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y + item.GetComponent<BoxCollider>().center.y * item.transform.localScale.y, 0.0f);
                newItemLocation.localPosition = new Vector3(0.0f, item.GetComponent<BoxCollider>().size.y * item.transform.localScale.y + newItemLocation.localPosition.y, 0.0f);
                //GameObject newGrabPosition = Instantiate(GrabPosition, item.transform.localPosition, item.transform.localRotation);
                //newGrabPosition.transform.SetParent(item.transform, true);
                //childGrabPositions.Add(newGrabPosition);
                Debug.Log(ingredients.Count);
                return;
            }
        }
        
    }

    public void RemoveItemFromPlate(GameObject item)
    {
        newItemLocation.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y - item.GetComponent<BoxCollider>().size.y * item.transform.localScale.y , 0.0f);
        ingredients.Remove(item);
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        
        //for(int i = 0; i < ingredients.Count; i++)
        //{
        //    if(ingredients[i] == item)
        //    {
        //        ingredients[i].GetComponent<Rigidbody>().isKinematic = false;
        //        ingredients[i].GetComponent<Rigidbody>().detectCollisions = true;
        //        ingredients[i].transform.parent = null;
        //        ingredients.Remove(ingredients[i]);
        //    }
        //}
    }

    public void gradingPlate()
    {
        if(finalScore == 0)
        {
            if (ingredients[0].tag == "TopBun")
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
            if (finalScore > 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                finalScore = 0;
            }
        }
    }

    public void loweringScore()
    {
        finalScore -= 1;
    }
}
