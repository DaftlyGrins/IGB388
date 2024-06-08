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
    Instantiate(slices[currentSliceCount], transform.position, transform.rotation);
        slices[currentSliceCount].GetComponent<GravityReset>().permissionToMove();
    
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