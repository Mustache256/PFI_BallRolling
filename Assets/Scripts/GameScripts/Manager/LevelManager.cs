using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Script used to manage aspects that are universal to all levels of the game
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
  //Function used for setup on loading a scene
  void Start()
  {
    //Retrieving player object
    player = FindObjectOfType<PlayerController>();
    //Set pause tracking bool to false
    gameIsPaused = false;
    //Setting time to run by default on load
    Time.timeScale = 1f;
    //Retrieving the name of the current active scene to store in associated variable
    sceneCheck = SceneManager.GetActiveScene().name;
  }

  //Function called every frame
  void Update()
  {
    //Check to see if ESC key has been pressed
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      //Setting game pause tracker variable to true
      gameIsPaused = true;
      //Calling function that handles games pausing
      PauseGame();
    }
    //Check to see if player position falls below the death height of the scene 
    if (player.transform.position.y < deathHeight.transform.position.y)
    {
      //Changing player state to be dead as teh player has fallen off the level
      player.currentState = PlayerController.STATE.DEAD;
      //Callign function that manages player death via falling
      StartCoroutine(deathFall());
    }
  }
  //Function that manages player falling death
  IEnumerator deathFall()
  {
    //Wait fir 1.5 seconds
    yield return new WaitForSeconds(1.5f);
    //Reset the current scene after player death
    SceneManager.LoadScene(sceneCheck);
    //Output to console for debugging
    Debug.Log("Scene reset due to player death");
  }
  //Function to reset level
  public void ResetLevel()
  {
    //Resets current scene
    SceneManager.LoadScene(sceneCheck);
    //Output to console for debugging
    Debug.Log("Scene Reset");
  }
  //Function to manage returning to the main menu via UI buttons
  public void ReturnToMenu()
  {
    //Loads main menu scene
    SceneManager.LoadScene("MainMenu");
    //Output to console for debugging
    Debug.Log("Main menu Scene Loaded");
  }
  //Function to manage loading next level upon level completion
  public void LoadNextLevel()
  {
    //Switch statement to determine which level to load based off of current scene name
    switch(sceneCheck)
    {
      //Case to load from tutorial to level 1
      case "Tutoriallevel":
        SceneManager.LoadScene("Level1");
        //Output to console for debugging
        Debug.Log("Level 1 Scene Loaded");
        break;
      //Case to load from level 1 to level 2
      case "Level1":
        SceneManager.LoadScene("Level2");
        //Output to console for debugging
        Debug.Log("Level 2 Scene Loaded");
        break;
      //Case to load from level 1 to level 2
      case "Level2":
        SceneManager.LoadScene("Level3");
        //Output to console for debugging
        Debug.Log("Level 3 Scene Loaded");
        break;
      //Case to load from level 1 to level 2
      case "Level3":
        SceneManager.LoadScene("Level4");
        //Output to console for debugging
        Debug.Log("Level 4 Scene Loaded");
        break;
      //Default in case of failed loading
      default:
        //Output to console for debugging
        Debug.Log("Failed to load a new level, returning player to main menu");
        //Resets player to main menu
        SceneManager.LoadScene("MainMenu");
        break;
    }
  }
  //Function to check for resume game button press within pause menu
  public void ButtonPress()
  {
    //Setting game pause tracker to false
    gameIsPaused = false;
    //Calling un pause game function
    UnpauseGame();
  }
  //Function that handles game pausing
  void PauseGame()
  {
    //Check to see if the game pause tracker bool if set to true
    if (gameIsPaused)
    {
      //Output to console for debugging
      Debug.Log("Game Paused");
      //Displaying pause menu canvas
      pauseMenuCanvas.SetActive(true);
      //Set timescale to 0 to pause scene
      Time.timeScale = 0f;
    }
    //Else statement in case of failed pause
    else
    {
      //Output to console for debugging
      Debug.Log("Error with pausing game has occured");
    }
  }
  //Function that handles unpausing the game
  void UnpauseGame()
  {
    //Check to see if game pause tracker bool is set to false
    if (gameIsPaused == false)
    {
      //Output to console for debugging
      Debug.Log("Game unpaused");
      //Set timescale to 1 to resume scene
      Time.timeScale = 1f;
    }
    //Else statement in case of failed unpause
    else
    {
      //Output to console for debugging
      Debug.Log("Error with exiting Pause Menu occured");
    }
  }
}
