using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTutorialScript : MonoBehaviour
{
  public GameObject PickupTutorialCanvas;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Showing Pickup and Score tutorial");
      PickupTutorialCanvas.SetActive(true);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Pickup and Score tutorial");
    PickupTutorialCanvas.SetActive(false);
    Time.timeScale = 1f;
  }
}
