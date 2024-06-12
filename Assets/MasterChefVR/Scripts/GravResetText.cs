
using TMPro;
using UnityEngine;

public class GravResetText : MonoBehaviour
{
  private Color startingColor;

  void Awake()
  {
    startingColor = GetComponent<TextMeshProUGUI>().color;
    Disable();
  }

  public void Disable()
  {
    TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
    text.text = "Disabled";
    text.color = Color.red;
  }

  public void Enable()
  {
    TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
    text.text = "Gravity";
    text.color = startingColor;
  }
}

