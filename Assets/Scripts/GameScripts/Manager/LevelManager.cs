using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Function used to manage aspects that are universal to all levels of the game
public class LevelManager : MonoBehaviour
{
  //Boolean used to store game pause state
  public static bool gameIsPaused;
  //Variable used to store reference to the pause menu canvas
  public GameObject pauseMenuCanvas;
  //Variable used to store the height in the level below which the player will die
  public Transform deathHeight;
  //Vairable used to store the name of the current scene
  private string sceneCheck;
  //Variable used to store reference to the player object
  private PlayerController player;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Variable used to store GUI element that shows player score
  private Text scoreText;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Variable used to store GUI element that shows player's final score at the end of the level
  private Text finalScore;
  //Variable used to store player score
  private int score;
  //Function used for setup on loading a scene
  void Start()
  {
    //Retrieving player object
    player = FindObjectOfType<PlayerController>();
    //Set pause tracking bool to false
    gameIsPaused = false;
    //Setting time to run by default on load
    Time.timeScale = 1f;
    //Setting score to 0 on load
    score = 0;
    //Setting GUI text showing score to show 0 on load
    scoreText.text = "Score: " + 0;
    //Retrieving the name of the current active scene to store in associated variable
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
