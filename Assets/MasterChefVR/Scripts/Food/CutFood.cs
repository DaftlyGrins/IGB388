using UnityEngine;

public class CutFood : MonoBehaviour
{
  public GameObject[] slices;
  public Mesh[] cutMesh;
  private int maxSlices;
  private int currentSliceCount = 0;

  void Start()
  {
    maxSlices = slices.Length;
  }

  public void Cut()
  {
    GameObject slice = Instantiate(slices[currentSliceCount], transform.position, transform.rotation);

    if (slice.GetComponent<Rigidbody>() != null)
    {
      slice.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
    } else if (slice.GetComponentInChildren<Rigidbody>() != null)
    {
      slice.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
    }

    if (slices.Length == 2){ 
      GameObject slice2 = Instantiate(slices[1], transform.position, transform.rotation);

      if (slice2.GetComponent<Rigidbody>() != null)
      {
        slice2.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
      } else if (slice2.GetComponentInChildren<Rigidbody>() != null)
      {
        slice2.GetComponent<Rigidbody>().useGravity  = Constants.gravityEnabled;
      }

      Destroy(this.gameObject);
    }
    
    if (currentSliceCount < cutMesh.Length)
    {
      GetComponent<MeshFilter>().mesh = cutMesh[currentSliceCount];
    }

    currentSliceCount++;

    if (currentSliceCount >= maxSlices)
    {
      Destroy(gameObject);
    }
  }
}