using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialScript : MonoBehaviour
{
  public GameObject movementTutorialCanvas;
  public GameObject uiCanvas;
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      Debug.Log("Showing Movement tutorial");
      movementTutorialCanvas.SetActive(true);
      uiCanvas.SetActive(false);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Movement tutorial");
    movementTutorialCanvas.SetActive(false);
    uiCanvas.SetActive(true);
    Time.timeScale = 1f;
  }
}
