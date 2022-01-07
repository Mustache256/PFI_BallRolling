using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialScript : MonoBehaviour
{
  //Script used to display the canvas containing the tutorial for game movement
  //Object that holds the tutorial canvas
  public GameObject movementTutorialCanvas;
  //Object that holds the GUI canvas
  public GameObject uiCanvas;
  //Function for detecting when the player collides with the pad that is used to display the tutorial
  private void OnTriggerEnter(Collider other)
  {
    //Checking for collision with player
    if(other.gameObject.tag == "Player")
    {
      //Output to console for debugging
      Debug.Log("Showing Movement tutorial");
      //Setting tutorial canvas to true so it will be displayed
      movementTutorialCanvas.SetActive(true);
      //Setting GUI canvas to false to hide it during tutorial
      uiCanvas.SetActive(false);
      //Pausing the game whilst the tutorial is being displayed
      Time.timeScale = 0f;
    }
  }
  //Function used to close the tutorial with a button
  public void CloseTutorial()
  {
    //Output to console for debugging
    Debug.Log("Hiding Movement tutorial");
    //Setting tutorial canvas to false so that the tutorial level can continue
    movementTutorialCanvas.SetActive(false);
    //Setting GUI canvas to true so it will be displayed
    uiCanvas.SetActive(true);
    //Resuming the game when the tutorial is over
    Time.timeScale = 1f;
  }
}
