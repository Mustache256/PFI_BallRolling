using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
  //Simple Script used by the main menu to close the game when the exit button is clicked
  public void exitGame()
  {
    //Outputs to console for error checking
    Debug.Log("Closing Game");
    //Closes the application
    Application.Quit();
  }
}
