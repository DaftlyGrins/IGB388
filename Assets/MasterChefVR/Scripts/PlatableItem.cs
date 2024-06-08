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
    public bool cooked = false;
    public bool burnt = false;

    // Variables to restrict large movements when cut with knife
    [SerializeField] private float restrictVelTime = 0.1f;
    [SerializeField] private float restrictVelValue = 1f;
    [SerializeField] private bool isVelRestricted = true;
    private Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        Invoke("UnrestrictVelocity", restrictVelTime);
    }

    void FixedUpdate(){
        if (isVelRestricted){rb.velocity = rb.velocity.normalized * restrictVelValue;};
    }

    void UnrestrictVelocity(){
        isVelRestricted = false;
    }

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
        if(this.gameObject.transform.parent != null)
        {
            if(this.gameObject.transform.parent.tag == "Plate")
            {
                plate.gameObject.transform.parent.GetComponent<Plate>().RemoveItemFromPlate(this.gameObject);
            }
        }

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
