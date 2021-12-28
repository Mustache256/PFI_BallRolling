using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
  public void exitGame()
  {
    Debug.Log("Closing Game");
    Application.Quit();
  }
}
