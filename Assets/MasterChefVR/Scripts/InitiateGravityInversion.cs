using System.Collections;
using UnityEngine;

public class InitiateGravityInversion : MonoBehaviour
{
    public GameObject lightManager;
    public float force = .02f;
    public GameObject teleportPoint;
    public GameObject objects;
    public GameObject cookingWell;
    public GameObject benchWell;
    public GameObject resetText;
    public void InitiateInversion()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        
        foreach(Rigidbody rb in allRigidbodies)
        {
          if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && rb.transform.IsChildOf(GameObject.Find("Objects").transform))
          {
              if (rb.gameObject.name != "Basket" && rb.gameObject.name != "Recipe") rb.AddForce(new Vector3(Random.Range(-1.0f, 1.0f), 1, Random.Range(-1.0f, 1.0f)) * force, ForceMode.Impulse);

                if (rb.gameObject.name != "Recipe") rb.useGravity = !rb.useGravity;
                          }
        }

        resetText.GetComponent<GravResetText>().Enable();

        StartCoroutine(WaitToTeleport());
    }

    void Awake()
    {
      DiegeticRotator rotator = GetComponent<DiegeticRotator>();
      if (rotator != null) rotator.Lock();
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
        AudioSource[] audio = GetComponents<AudioSource>();

        if (Constants.gravityEnabled)
        {
            GetComponent<DiegeticRotator>().Lock();
            lightManager.GetComponent<GravityLighting>().Kill();

            audio[0].Play();
            audio[1].Play();

            resetText.GetComponent<GravResetText>().Disable();
        
            foreach(Rigidbody rb in allRigidbodies)
            {
                if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && !cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) && !benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
                {
                    rb.useGravity = Constants.gravityEnabled;
                }
            }
        } else 
        {
            resetText.GetComponent<GravResetText>().Enable();

            foreach(Rigidbody rb in allRigidbodies)
            {
                if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && !cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) && !benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
                {
                    audio[2].Play();
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

    public bool debug;
    void Update()
    {
        if (!debug) return;
        Hazard();
        debug = false;
    }

    public GameObject lever;

    public void Hazard()
    {
        AudioSource[] audio = GetComponents<AudioSource>();

        audio[0].Play();
        audio[1].Play();

        resetText.GetComponent<GravResetText>().Disable();

        lever.GetComponent<DiegeticRotator>().Lock();

        StartCoroutine(WaitToHazard());
    }

    IEnumerator WaitToHazard()
    {
        yield return new WaitForSeconds(11);

        AudioSource[] audio = GetComponents<AudioSource>();

        audio[0].Stop();
        audio[1].Stop();
        audio[2].Play();

        GameObject[] pans = GameObject.FindGameObjectsWithTag("Pan");
        GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");
        GameObject[] plates = GameObject.FindGameObjectsWithTag("Plate");

        foreach(GameObject pan in pans)
        {
            Respawner res = pan.GetComponent<Respawner>();
            if (res != null) res.enabled = false;
        }

        foreach(GameObject knife in knives)
        {
            Respawner res = knife.GetComponent<Respawner>();
            if (res != null) res.enabled = false;     
        }

        foreach(GameObject plate in plates)
        {
            Respawner res = plate.GetComponent<Respawner>();
            if (res != null) res.enabled = false;
        }

        Vector3 randomVector = Vector3.zero;

        do
        {
            int randomDirection = Random.Range(0, 6);

            switch (randomDirection)
            {
                case 0:
                    randomVector = Vector3.forward;
                    break;
                case 1:
                    randomVector = Vector3.right;
                    break;
                case 2:
                    randomVector = Vector3.back;
                    break;
                case 3:
                    randomVector = Vector3.left;
                    break;
                case 4:
                    randomVector = Vector3.up;
                    break;
                case 5:
                    randomVector = Vector3.down;
                    break;
            }
        } while (randomVector == Constants.gravityDirection);

        Physics.gravity = randomVector * 9.81f;
        Constants.gravityDirection = randomVector;
        Constants.gravityEnabled = true;
        
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        lightManager.GetComponent<GravityLighting>().Kill(true);

        foreach(Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && !cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) && !benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
            {
                rb.useGravity = Constants.gravityEnabled;
            }

            if (cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) || benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
            {
                rb.useGravity = false;
            }
        }
    }

    public void HazardCleanup()
    {
        AudioSource[] audio = GetComponents<AudioSource>();

        audio[3].Play();

        resetText.GetComponent<GravResetText>().Enable();

        GameObject[] pans = GameObject.FindGameObjectsWithTag("Pan");
        GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");
        GameObject[] plates = GameObject.FindGameObjectsWithTag("Plate");

        foreach(GameObject pan in pans)
        {
            Respawner res =  pan.GetComponent<Respawner>();
            if (res != null) res.enabled = true;
        }

        foreach(GameObject knife in knives)
        {
            Respawner res = knife.GetComponent<Respawner>();
            if (res != null) res.enabled = true;     
        }

        foreach(GameObject plate in plates)
        {
            Respawner res = plate.GetComponent<Respawner>();
            if (res != null) res.enabled = true;
        }

        Constants.gravityEnabled = false;
        
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        foreach(Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject.layer == LayerMask.NameToLayer("GravityAffected") && !cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) && !benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
            {
                rb.useGravity = Constants.gravityEnabled;
                rb.AddForce(-Constants.gravityDirection * force, ForceMode.Impulse);
            }

            if (cookingWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject) || benchWell.GetComponent<GravityWell>().objectsInWell.Contains(rb.gameObject))
            {
                rb.useGravity = true;
            }
        }

        Physics.gravity = new Vector3(0, -9.81f, 0);
    }
}
