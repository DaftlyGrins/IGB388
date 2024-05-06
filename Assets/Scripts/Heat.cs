using UnityEngine;

public class Heat : MonoBehaviour
{
    public float duration = 1.0f;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
        this.GetComponent<Collider>().enabled = false;
        this.GetComponent<Collider>().enabled = true;
    }

    void Update()
    {
        if (Time.time > spawnTime + duration)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Food food = other.gameObject.GetComponent<Food>();
        if (food == null) return;
        food.Cook(5f);
    }
}
