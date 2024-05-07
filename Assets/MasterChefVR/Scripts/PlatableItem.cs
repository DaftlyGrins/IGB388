using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatableItem : MonoBehaviour
{
    public bool isNearPlate = false;
    public bool isNearBasket = false;
    public Collider plate;
    public Collider basket;
    public bool inBasket = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Plate")
        {
            isNearPlate = true;
            plate = other;
        }
        else if (other.transform.tag == "Basket")
        {
            isNearBasket = true;
            basket = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Plate")
        {
            isNearPlate = false;
        }
        if (other.transform.tag == "Basket")
        {
            isNearBasket = false;
        }
    }

    public void GrabbedFromPlateorBasket()
    {
        if (inBasket || isNearPlate)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            this.transform.parent = null;
        }
    }

    public void ReleasedNearPlate()
    {
        if (isNearPlate)
        {
            plate.gameObject.transform.parent.GetComponent<Plate>().AddItemToPlate(this.gameObject);
        }
    }

    public void ReleasedNearBasket()
    {
        if (isNearBasket)
        {
            inBasket = true;
            basket.gameObject.transform.parent.GetComponent<Basket>().AddItemToBasket(this.gameObject);
        }
    }

    public void EnsureNotKinematic()
    {
        if (!isNearPlate && !isNearBasket)
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    
}
