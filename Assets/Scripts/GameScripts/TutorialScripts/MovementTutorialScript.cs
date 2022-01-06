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
      Debug.Log("Showing Movement tutorial");
      MovementTutorialCanvas.SetActive(true);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Movement tutorial");
    MovementTutorialCanvas.SetActive(false);
    Time.timeScale = 1f;
  }
}
