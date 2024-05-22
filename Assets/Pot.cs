using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    // Adding pot to well stuff
    private bool inProximetyOfWell = false;
    private GameObject well;
    private Vector3 wellPosition;
    private bool onWell = false;
    private Rigidbody rb;
    public Vector3 wellOffset;

    // Moving the pot down and up the well
    private float wellRotatorValue;
    public MeshRenderer potLiquidMR;
    private float addLiquidValue = 0.75f;

    // Add carrots or drumsticks
    public GameObject carrots;
    public GameObject drumsticks;

    // Pot into fire action
    private GameObject potLocation;
    private bool inProximetyOfFire = false;
    private bool onFire = false;

    void Start(){
        rb = GetComponent<Rigidbody>();
        carrots.SetActive(false);
        drumsticks.SetActive(false);
    }

    void Update(){
        // Move to position indicated by rotator
        if(onWell){
            wellRotatorValue = GameManager.Instance.wellGiantLevel.GetComponent<DiegeticRotator>().currentValue;
            this.gameObject.transform.position = wellPosition + wellOffset - new Vector3(0.0f, wellRotatorValue, 0.0f);

            // Add liquid wehn below threshold
            if (wellRotatorValue > addLiquidValue){
                potLiquidMR.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Well"){
            inProximetyOfWell = true;
            well = other.gameObject;
        }
        else if (other.transform.tag == "PotLocation"){
            inProximetyOfFire = true;
            potLocation = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.tag == "Well")
        {
            inProximetyOfWell = false;
        }
        else if (other.transform.tag == "PotLocation"){
            inProximetyOfFire = false;
        }
    }

    public void GrabFunction(){
        if (onWell){
            onWell = false;
        }
        else if(onFire){
            onFire = false;
        }
    }

    public void ReleaseFunction(){
        if (inProximetyOfWell){
            wellPosition = well.transform.position;
            this.gameObject.transform.position = wellPosition + wellOffset;
            this.gameObject.transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
            onWell = true;
        }
        else if(inProximetyOfFire){
            this.gameObject.transform.position = potLocation.transform.position;
            this.gameObject.transform.localRotation = Quaternion.identity;
            rb.isKinematic = true;
            onFire = true;
        }
    }

    public void EnableFood(string foodName){
        if (foodName == "Carrot"){
            carrots.SetActive(true);
        }
        else if (foodName == "Drumstick"){
            drumsticks.SetActive(true);
        }
    }
}
