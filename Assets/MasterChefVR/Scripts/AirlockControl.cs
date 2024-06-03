using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AirlockControl : MonoBehaviour
{
  public bool disabled = true;
  public GameObject airlockDoor;
  public GameObject textDisplay;
  public GameObject handDisplay;
  public Sprite enabledSprite;
  public GameObject[] lights;

  private Color enabledColor = new Color(
    int.Parse("5A", System.Globalization.NumberStyles.HexNumber) / 255f,
    int.Parse("FF", System.Globalization.NumberStyles.HexNumber) / 255f,
    int.Parse("FF", System.Globalization.NumberStyles.HexNumber) / 255f
  );

  void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player")) return;
    if (disabled)
    {
      GetComponent<AudioSource>().Play();
    } else {
      airlockDoor.GetComponent<SlidingBlastDoor>().Open();
      GetComponent<Collider>().enabled = false;
    }
  }

  public void EnableAirlock()
  {
    disabled = false;

    TextMeshProUGUI text = textDisplay.GetComponent<TextMeshProUGUI>();

    text.text = "Enabled";
    text.color = enabledColor;

    Image hand = handDisplay.GetComponent<Image>();
    hand.sprite = enabledSprite;

    foreach (GameObject light in lights)
    {
      Light lightComponent = light.GetComponent<Light>();
      lightComponent.color = enabledColor;
    }
  }
}
