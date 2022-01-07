using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  //Scene management script for the main menu to use, allowing the player to pick which level of the game they want to load through level selection buttons
  //Function for loading tutorial level
  public void tutorialScene()
  {
    //Outputs to console for debugging
    Debug.Log("Tutorial Scene Loaded");
    //Load Tutorial Level
    SceneManager.LoadScene("TutorialLevel");
  }
  //Function for loading level 1
  public void level1Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 1 Scene Loaded");
    //Load Level 1
    SceneManager.LoadScene("Level1");
  }
  //Function for loading level 2
  public void level2Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 2 Scene Loaded");
    //Load Level 2
    SceneManager.LoadScene("Level2");
  }
  //Function for loading level 3
  public void level3Scene()
  {
    Debug.Log("Level 3 Scene Loaded");
    //Load Level 3
    SceneManager.LoadScene("Level3");
  }
  //Function for loading level 4
  public void level4Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 4 Scene Loaded");
    //Load Level 4
    SceneManager.LoadScene("Level4");
  }
}
