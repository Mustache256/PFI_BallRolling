using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTutorialScript : MonoBehaviour
{
  public GameObject timerTutorialCanvas;
  public GameObject score;
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Showing Timer and Objective tutorial");
      timerTutorialCanvas.SetActive(true);
      score.SetActive(false);
      Time.timeScale = 0f;
    }
  }
  public void CloseTutorial()
  {
    Debug.Log("Hiding Timer and Objective tutorial");
    timerTutorialCanvas.SetActive(false);
    score.SetActive(true);
    Time.timeScale = 1f;
  }
}
