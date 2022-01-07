using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTutorialScript : MonoBehaviour
{
  //Script used to display the canvas containing the tutorial for the level timer
  //Object that holds the tutorial canvas
  public GameObject timerTutorialCanvas;
  //Object that contains the part of the GUI that needs to be hidden during this tutorial
  public GameObject score;
  //Function for detecting when the player collides with the pad that is used to display the tutorial
  private void OnTriggerEnter(Collider other)
  {
    //Checking for collision with player
    if (other.gameObject.tag == "Player")
    {
      //Output to console for debugging
      Debug.Log("Showing Timer and Objective tutorial");
      //Setting tutorial canvas to true so it will be displayed
      timerTutorialCanvas.SetActive(true);
      //Hiding unnecesary GUI elements
      score.SetActive(false);
      //Pausing the game whilst the tutorial is being displayed
      Time.timeScale = 0f;
    }
  }
  //Function used to close the tutorial with a button
  public void CloseTutorial()
  {
    //Output to console for debugging
    Debug.Log("Hiding Timer and Objective tutorial");
    //Setting tutorial canvas to false so that the tutorial level can continue
    timerTutorialCanvas.SetActive(false);
    //Showing hidden GUI elements so game can continue
    score.SetActive(true);
    //Resuming the game when the tutorial is over
    Time.timeScale = 1f;
  }
}
