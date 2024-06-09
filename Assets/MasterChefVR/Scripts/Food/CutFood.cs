using UnityEngine;

public class CutFood : MonoBehaviour
{
  public GameObject[] slices;
  public Mesh[] cutMesh;
  private int maxSlices;
  private int currentSliceCount = 0;
<<<<<<< Updated upstream
=======
  //public bool hasCutAngle;
  //[Tooltip("Will only cut PERPENDICULAR to this vector (+- 30 degrees")]
  //public Vector3 cutAngle;
>>>>>>> Stashed changes

  void Start()
  {
    maxSlices = slices.Length;
  }

  public void Cut()
  {
    Instantiate(slices[currentSliceCount], transform.position, transform.rotation);

    if (slices.Length == 2){ 
      Instantiate(slices[1], transform.position, transform.rotation);
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