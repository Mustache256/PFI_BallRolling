using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTutorialScript : MonoBehaviour
{
  public GameObject pickupTutorialCanvas;
  public GameObject timer;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Showing Pickup and Score tutorial");
      pickupTutorialCanvas.SetActive(true);
      timer.SetActive(false);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Pickup and Score tutorial");
    pickupTutorialCanvas.SetActive(false);
    timer.SetActive(true);
    Time.timeScale = 1f;
  }
}
