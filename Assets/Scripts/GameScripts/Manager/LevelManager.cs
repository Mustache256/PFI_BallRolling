using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
  public static bool gameIsPaused;
  public GameObject pauseMenuCanvas;
  public GameObject uiCanvas;
  [SerializeField]
  private Text scoreText;
  [SerializeField]
  private int score;
  // Start is called before the first frame update
  void Start()
  {
    gameIsPaused = false;
    Time.timeScale = 1f;
    score = 0;
    scoreText.text = "Score: " + 0;
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
  public void ReturnToMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("Main menu Scene Loaded");
  }
  public void LoadNextLevel()
  {
    SceneManager.LoadScene("Level1");
    Debug.Log("Level 1 Scene Loaded");
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
      uiCanvas.SetActive(false);
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
      uiCanvas.SetActive(true);
      Time.timeScale = 1f;
    }
    else
    {
      Debug.Log("Error with exiting Pause Menu occured");
    }
  }

  public void setScore(int scoreToAdd)
  {
    score += scoreToAdd;
    scoreText.text = "Score: " + score.ToString();
  }
}
