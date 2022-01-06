using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTutorialScript : MonoBehaviour
{
  public GameObject portalTutorialCanvas;
  public GameObject uiCanvas;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Showing Portal tutorial");
      portalTutorialCanvas.SetActive(true);
      uiCanvas.SetActive(false);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Portal tutorial");
    portalTutorialCanvas.SetActive(false);
    uiCanvas.SetActive(true);
    Time.timeScale = 1f;
  }
}
