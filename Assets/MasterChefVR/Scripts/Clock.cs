using UnityEngine;

public class Clock : MonoBehaviour
{
    public float rotationDuration; // in seconds
    public GameObject gravityHazard;

    private float startTime;
    public bool isRotating = false;

    private bool firstHazard;
    private bool secondHazard;

    void Update()
    {
        if (isRotating)
        {
            // Calculate the current rotation angle based on time elapsed
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            float angle = Mathf.Lerp(0, 360, t);

            if (angle >= 140 && !firstHazard)
            {
                gravityHazard.GetComponent<InitiateGravityInversion>().Hazard();
                firstHazard = true;
            }

            if (angle >= 200 && !secondHazard)
            {
                gravityHazard.GetComponent<InitiateGravityInversion>().Hazard();
                secondHazard = true;
            }

            // Apply rotation
            transform.rotation = Quaternion.Euler(0, -90.0f, angle);

            // Check if rotation is complete
            if (elapsedTime >= rotationDuration)
            {
                isRotating = false;
                GameManager.Instance.dialogueManager.GetComponent<Dialogue>().PlayClip(GameManager.Instance.judges[2].gameObject, 0);
            }
        }
    }

    public void StopRotation()
    {
        if (isRotating){
            GameManager.Instance.dialogueManager.GetComponent<Dialogue>().PlayClip(GameManager.Instance.judges[2].gameObject, 0);
        }
        isRotating = false;
    }

    public void StartRotation()
    {
        // Start the rotation
        startTime = Time.time;
        isRotating = true;
    }
}
