using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantStomp : MonoBehaviour
{
    public float stompStrength;
    [SerializeField] private Rigidbody rb;
    public float secToStomp = 5f;

    void Update()
    {
        secToStomp -= Time.deltaTime;
        if (secToStomp <= 0)
        {
            secToStomp = 5f;
            Stomp();
        }
    }

    public void Stomp()
    {
        rb.velocity += new Vector3(0, stompStrength, 0);
    }
}
