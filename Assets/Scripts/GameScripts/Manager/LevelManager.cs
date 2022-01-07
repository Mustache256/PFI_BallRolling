using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
  public static bool gameIsPaused;
  public GameObject pauseMenuCanvas;
  public Transform deathHeight;

  private string sceneCheck;
  private PlayerController player;
  [SerializeField]
  private Text scoreText;
  [SerializeField]
  private Text finalScore;
  //[SerializeField]
  private int score;
  // Start is called before the first frame update
  void Start()
  {
    player = FindObjectOfType<PlayerController>();
    gameIsPaused = false;
    Time.timeScale = 1f;
    score = 0;
    scoreText.text = "Score: " + 0;
    sceneCheck = SceneManager.GetActiveScene().name;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      gameIsPaused = true;
      PauseGame();
    }
    if (player.transform.position.y < deathHeight.transform.position.y)
    {
      player.currentState = PlayerController.STATE.DEAD;
      StartCoroutine(deathFall());
    }
  }
  IEnumerator deathFall()
  {
    yield return new WaitForSeconds(1.5f);
    SceneManager.LoadScene(sceneCheck);
  }
  public void ResetLevel()
  {
    SceneManager.LoadScene(sceneCheck);
  }
  public void ReturnToMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("Main menu Scene Loaded");
  }
  public void LoadNextLevel()
  {
    switch(sceneCheck)
    {
      case "Tutoriallevel":
        SceneManager.LoadScene("Level1");
        Debug.Log("Level 1 Scene Loaded");
        break;
      case "Level1":
        SceneManager.LoadScene("Level2");
        Debug.Log("Level 2 Scene Loaded");
        break;
      case "Level2":
        SceneManager.LoadScene("Level3");
        Debug.Log("Level 3 Scene Loaded");
        break;
      case "Level3":
        SceneManager.LoadScene("Level4");
        Debug.Log("Level 4 Scene Loaded");
        break;
      default:
        Debug.Log("Failed to load a new level, returning player to main menu");
        SceneManager.LoadScene("MainMenu");
        break;
    }
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
    if (gameIsPaused == false)
    {
      Debug.Log("Game unpaused");
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
    finalScore.text = score.ToString();
  }
  public int getScore()
  {
    return score;
  }
}
