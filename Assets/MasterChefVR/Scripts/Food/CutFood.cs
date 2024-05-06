using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFood : MonoBehaviour
{
  public GameObject[] slices;
  public GameObject cutModel;
  private int maxSlices;
  private int currentSliceCount = 0;

  void Start()
  {
    maxSlices = slices.Length;
  }

  public void Cut()
  {
    Instantiate(slices[currentSliceCount], transform.position, transform.rotation);
    
    if (currentSliceCount == 0)
    {
      // TODO: Set the cut model to be the held item, rather than the whole model
      // Instantiate(cutModel, transform.position, transform.rotation);
    }

    currentSliceCount++;

    if (currentSliceCount >= maxSlices)
    {
      Destroy(gameObject);
    }
  }
}