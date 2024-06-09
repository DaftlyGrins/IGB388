using UnityEngine;

public class Dialogue : MonoBehaviour
{
  [SerializeField] private GameObject judgeFrancis;
  [SerializeField] private GameObject judgeTina;
  [SerializeField] private GameObject judgeJordan;
  public AudioClip[] judgeTinaLines;
  public AudioClip[] judgeFrancisLines;
  public AudioClip[] judgeJordanLines;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public void PlayIntroduction()
  {
    judgeFrancis.GetComponent<AudioSource>().Play();
  }

  public void PlayClip(GameObject judge, int soundIndex){
    if (judge == judgeFrancis){
      judgeFrancis.GetComponent<AudioSource>().clip = judgeFrancisLines[soundIndex];
      judgeFrancis.GetComponent<AudioSource>().Play();
    }
    else if (judge == judgeTina){
      judgeTina.GetComponent<AudioSource>().clip = judgeTinaLines[soundIndex];
      judgeTina.GetComponent<AudioSource>().Play();
    }
    else {
      judgeJordan.GetComponent<AudioSource>().clip = judgeJordanLines[soundIndex];
      judgeJordan.GetComponent<AudioSource>().Play();
    }
  }
}
