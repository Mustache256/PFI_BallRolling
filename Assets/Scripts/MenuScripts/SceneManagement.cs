using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public void tutorialScene()
  {
    Debug.Log("Tutorial Scene Loaded");
    SceneManager.LoadScene("MiniGame");
  }
  public void level1Scene()
  {
    Debug.Log("Level 1 Scene Loaded");
    SceneManager.LoadScene("MiniGame");
  }
  public void level2Scene()
  {
    Debug.Log("Level 2 Scene Loaded");
    SceneManager.LoadScene("MiniGame");
  }
  public void level3Scene()
  {
    Debug.Log("Level 3 Scene Loaded");
    SceneManager.LoadScene("MiniGame");
  }
  public void level4Scene()
  {
    Debug.Log("Level 4 Scene Loaded");
    SceneManager.LoadScene("MiniGame");
  }
}
