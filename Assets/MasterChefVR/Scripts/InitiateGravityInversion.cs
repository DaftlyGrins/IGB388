using System.Collections;
using UnityEngine;

public class InitiateGravityInversion : MonoBehaviour
{
    public GameObject[] skipInitiate;
    public GameObject lightManager;
    public float force = .02f;
    public void InitiateInversion()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        
        foreach(Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && rb.transform.IsChildOf(GameObject.Find("Objects").transform)
                && rb.gameObject.name != "Basket" && rb.gameObject.name != "Recipe")
            {
                rb.useGravity = !rb.useGravity;
                rb.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f)) * force, ForceMode.Impulse);
            }
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
                    rb.useGravity = !rb.useGravity;
                }
            }
        } else 
        {
            foreach(Rigidbody rb in allRigidbodies)
            {
                if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected"))
                {
                    rb.useGravity = !rb.useGravity;
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
