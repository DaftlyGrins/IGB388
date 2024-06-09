using System.Collections;
using UnityEngine;

public class InitiateGravityInversion : MonoBehaviour
{
    public GameObject lightManager;
    public float force = .02f;
    public GameObject teleportPoint;
    public GameObject objects;
    public void InitiateInversion()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        
        foreach(Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && rb.transform.IsChildOf(GameObject.Find("Objects").transform))
            {
                if (rb.gameObject.name != "Basket" && rb.gameObject.name != "Recipe") rb.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f)) * force, ForceMode.Impulse);

                rb.useGravity = !rb.useGravity;
            }
        }

        StartCoroutine(WaitToTeleport());
    }

    IEnumerator WaitToTeleport()
    {
        yield return new WaitForSeconds(1.5f);

        teleportPoint.SetActive(true);
        CustomGrabbable[] customGrabbables = objects.GetComponentsInChildren<CustomGrabbable>();

        foreach (CustomGrabbable grabbable in customGrabbables)
        {
            grabbable.enabled = true;
        }

        GrabOutlineController[] grabOutlineControllers = objects.GetComponentsInChildren<GrabOutlineController>();

        foreach (GrabOutlineController grabOutlineController in grabOutlineControllers)
        {
            grabOutlineController.enabled = true;
        }
    }

    public void Invert()
    {
        Constants.gravityEnabled = !Constants.gravityEnabled;
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        if (Constants.gravityEnabled)
        {
            GetComponent<DiegeticRotator>().Lock();
            lightManager.GetComponent<GravityLighting>().Kill();
            GetComponent<AudioSource>().Play();
        
            foreach(Rigidbody rb in allRigidbodies)
            {
                if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected"))
                {
                    rb.useGravity = Constants.gravityEnabled;
                }
            }
        } else 
        {
            foreach(Rigidbody rb in allRigidbodies)
            {
                if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected"))
                {
                    rb.useGravity = Constants.gravityEnabled;
                    if (!rb.useGravity) rb.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f)) * force, ForceMode.Impulse);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Constants.gravityEnabled) return;
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (!rb || rb.gameObject.layer != LayerMask.NameToLayer("GravityAffected")) return;
        
        rb.velocity = new Vector3(rb.velocity.x, -(rb.velocity.y + force), rb.velocity.z);         
    }
}
