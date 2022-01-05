using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialScript : MonoBehaviour
{
  public GameObject MovementTutorialCanvas;
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      MovementTutorialCanvas.SetActive(true);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    MovementTutorialCanvas.SetActive(false);
    Time.timeScale = 1f;
  }
}
