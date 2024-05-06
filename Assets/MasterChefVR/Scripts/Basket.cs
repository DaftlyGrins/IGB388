using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject[] ingredients;
    public Transform newItemLocation;

    public void AddItemToBasket(GameObject item)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            if (ingredients[i] == null)
            {
                ingredients[i] = item;
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.SetParent(this.gameObject.transform, true);
                item.transform.localRotation = Quaternion.identity;
                item.transform.localPosition = new Vector3(0.0f, newItemLocation.localPosition.y + item.GetComponent<BoxCollider>().center.y * item.transform.localScale.y, 0.0f);
                newItemLocation.localPosition = new Vector3(0.0f, item.GetComponent<BoxCollider>().size.y * item.transform.localScale.y + newItemLocation.localPosition.y, 0.0f);
                return;
            }
        }
        
    }
}
