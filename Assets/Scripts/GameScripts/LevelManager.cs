using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  public static bool gameIsPaused;
  public GameObject pauseMenuCanvas;
  private PlayerController player;
  private CameraController mainCamera;
  // Start is called before the first frame update
  void Start()
  {
    gameIsPaused = false;
    Time.timeScale = 1f;
    player = FindObjectOfType<PlayerController>();
    mainCamera = FindObjectOfType<CameraController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      gameIsPaused = true;
      PauseGame();
    }
  }
  public void returnToMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("Main menu Scene Loaded");
  }
  public void ButtonPress()
  {
    gameIsPaused = false;
    UnpauseGame();
  }
  void PauseGame()
  {
    if (gameIsPaused)
    {
      Debug.Log("Game Paused");
      pauseMenuCanvas.SetActive(true);
      Time.timeScale = 0f;
    }
    else
    {
      Debug.Log("Error with pausing game has occured");
    }
  }
  void UnpauseGame()
  {
    if (!gameIsPaused)
    {
      Debug.Log("Game unpaused");
      Time.timeScale = 1f;
    }
    else
    {
      Debug.Log("Error with exiting Pause Menu occured");
    }
  }
}
