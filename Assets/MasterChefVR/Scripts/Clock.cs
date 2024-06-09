using UnityEngine;

public class Clock : MonoBehaviour
{
    public float rotationDuration; // in seconds

    private float startTime;
    public bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            // Calculate the current rotation angle based on time elapsed
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / rotationDuration);
            float angle = Mathf.Lerp(0, 360, t);

            // Apply rotation
            transform.rotation = Quaternion.Euler(0, -90.0f, angle);

            // Check if rotation is complete
            if (elapsedTime >= rotationDuration)
            {
                isRotating = false;
            }
        }
    }

    public void StartRotation()
    {
        // Start the rotation
        startTime = Time.time;
        isRotating = true;
    }
}
