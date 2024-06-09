using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Plate : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>{};
    public Transform newItemLocation;
    public int finalScore;
    public float grade;

    public void AddItemToPlate(GameObject item)
    {
        if (ingredients.Count == 6) return;
        if (!GameManager.Instance.clock.isRotating) return; // If not current allowed to cook cause the timer is off dont allow plating 

        ingredients.Add(item);
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().detectCollisions = false;
        item.transform.SetParent(this.gameObject.transform, true);
        item.transform.localRotation = Quaternion.identity;
        item.transform.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y + (item.GetComponent<BoxCollider>().size.y/2 - item.GetComponent<BoxCollider>().center.y) * item.transform.localScale.y, 0.0f);
        newItemLocation.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y + item.GetComponent<BoxCollider>().size.y * item.transform.localScale.y, 0.0f);
        //newItemLocation.localPosition = new Vector3(0.0f, item.GetComponent<BoxCollider>().size.y/2 * item.transform.localScale.y + newItemLocation.localPosition.y, 0.0f);            
    }

    public void RemoveItemFromPlate(GameObject item)
    {
        if (!GameManager.Instance.clock.isRotating) return; // If not current allowed to cook cause the timer is off dont allow plating 
        if (ingredients.Contains(item)) {
            newItemLocation.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y - item.GetComponent<BoxCollider>().size.y, 0.0f);
            item.transform.localRotation = Quaternion.identity;
            ingredients.Remove(item);
            item.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            item.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            item.transform.parent = null;
        }
    }

    public void GradePlate()
    {
        grade = 0.0f;

        if (ingredients.Count == 0) return;

        // Adding score based on if player has at least one of a particular item
        string[] meshNames = new string[6] {"BunBottom", "Steak", "LettuceLeaf", "CheeseSlice", "TomatoSlice", "BunTop"};
        
        foreach (string item in meshNames)
        {
            for (int i = 0; i < ingredients.Count; i++){
                if (ingredients[i] == null){
                    break;
                }

                if (ingredients[i].GetComponent<MeshFilter>().mesh.name == null){ // Can only happen if it is meat
                    if (item == "Steak"){ // Check that the item we are checking for is meat
                        grade += 1f;
                        break;
                    }
                    else {
                        continue;
                    }
                }
                else {
                    string nameToCheck = ingredients[i].GetComponent<MeshFilter>().mesh.name;
                    if (nameToCheck.Substring(0, nameToCheck.Length - 9) == item || nameToCheck.Substring(0, nameToCheck.Length - 10) == item) // Checking for all variants using substring
                    {
                        grade += 1f;
                        break;
                    }
                    else{
                        continue;
                    }
                }
            }
        }

        // Add score if item is in correct location
        for (int i = 0; i < ingredients.Count; i++){
            if (ingredients[i] == null){
                break;
            }

            if (ingredients[i].name.Contains(meshNames[i])){
                grade += 1f;

                // If it is three and in correct spot
                if (ingredients[i].name.Contains("3")){
                    grade += 1f;
                }
            }
        }

        // Check if Buns are toasted, must be in correct location
        if (ingredients[0] != null){
            PlatableItem burgerBun = ingredients[0].GetComponent<PlatableItem>();
            if (burgerBun != null && burgerBun.cooked){
                grade += 3f;
            }
        }

        if (ingredients.Count < 2) return;

        // Check if Steak is cooked, must be in right postition
        if (ingredients[1] != null){
            CookFood steak = ingredients[1].GetComponentInChildren<CookFood>();
            if (steak != null){
                grade += 15.0f - Mathf.Abs(15.0f - steak.timeCooked);
            }
        }

        if (ingredients.Count < 6) return;

        if (ingredients[5] != null){
            PlatableItem burgerBun = ingredients[0].GetComponent<PlatableItem>();
            if (burgerBun != null && burgerBun.cooked){
                grade += 3f;
            }
        }

        // Print Score
        Debug.Log(grade);
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