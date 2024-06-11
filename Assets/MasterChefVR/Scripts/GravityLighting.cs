using System.Collections;
using UnityEngine;

public class GravityLighting : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject[] energyPylons;
    public Material disabledPylonMaterial;
    public Material enabledPylonMaterial;
    public GameObject gravityResetSwitch;
    public GameObject[] energyCyl;
    public GameObject cylLight;
    public GameObject hazard;

    private Color initialPylonColor;

    public bool start;

    void Start()
    {
        initialPylonColor = energyPylons[0].transform.GetChild(0).GetComponent<Light>().color;
    }

    void Update()
    {
        if (!start) return;

        Kill();
        start = false;
    }

    public void Kill(bool wasHazard = false)
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

        foreach (GameObject enerygyPylon in energyPylons)
        {
            Material[] materials = enerygyPylon.GetComponent<MeshRenderer>().materials;
            materials[0] = disabledPylonMaterial;
            enerygyPylon.GetComponent<MeshRenderer>().materials = materials;
            
            enerygyPylon.GetComponentInChildren<Light>().color = Color.red;
        }

        foreach (GameObject cyl in energyCyl)
        {
            cyl.GetComponent<MeshRenderer>().material = disabledPylonMaterial;
            cylLight.GetComponent<Light>().color = Color.red;
        }

        StartCoroutine(WaitToReenable(wasHazard));
    }

    IEnumerator WaitToReenable(bool wasHazard = false)
    {
        yield return new WaitForSeconds(8.0f);

        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

        foreach (GameObject enerygyPylon in energyPylons)
        {
            Material[] materials = enerygyPylon.GetComponent<MeshRenderer>().materials;
            materials[0] = enabledPylonMaterial;
            enerygyPylon.GetComponent<MeshRenderer>().materials = materials;

            enerygyPylon.GetComponentInChildren<Light>().color = initialPylonColor;
        }

        foreach (GameObject cyl in energyCyl)
        {
            cyl.GetComponent<MeshRenderer>().material = enabledPylonMaterial;
            cylLight.GetComponent<Light>().color = initialPylonColor;
        }

        gravityResetSwitch.GetComponent<DiegeticRotator>().Unlock();

        if (wasHazard)
        {
            hazard.GetComponent<InitiateGravityInversion>().HazardCleanup();
        } else{
            gravityResetSwitch.GetComponent<InitiateGravityInversion>().Invert();
        }
    }
}
