using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SceneManagement : MonoBehaviour
{
  //Scene management script for the main menu to use, allowing the player to pick which level of the game they want to load through level selection buttons and speech
  //Variables used to store the menu objects, so they can be used by the script to allow the player to use speech to control the menu
  [SerializeField]
  private GameObject mainMenu;
  [SerializeField]
  private GameObject optionsMenu;
  [SerializeField]
  private GameObject levelSelect;
  //Keywords string used by the PhraseRecognizer as an index for what commands to listen for
  private string[] keywords = new string[] { "start", "options", "exit", "back to menu", "tutorial", "level one", "level two", "level three", "level four" };
  //Confidence level variable that determines how confident the program has to be in an input before it can except said input
  public ConfidenceLevel confidence = ConfidenceLevel.Medium;
  //PhraseRecogniser used to detect when a keyword is said
  protected PhraseRecognizer recognizer;
  //String that stores teh word the player said
  protected string word;
  //Function used for setup on loading a scene
  void Start()
  {
    //Checks to see if there are keywords to listen for, otherwise the code wont execute
    if (keywords != null)
    {
      //Assigning the parameters to the PhraseRecognizer so it knows what to listen for and how confident it has to be in an input before it can act
      recognizer = new KeywordRecognizer(keywords, confidence);
      //Calls the function that determines what to do when a phrase is recognised and passes the keyword into said function
      recognizer.OnPhraseRecognized += RecognizerOnPhraseRecognized;
      //Starts the PhraseRecogniser, meaning it has begun listening for kyeword inputs
      recognizer.Start();
      //Output to console for debugging
      Debug.Log(recognizer.IsRunning);
    }
    //Outputs all the input audio devices from the computer into the console for debugging
    foreach (var device in Microphone.devices)
    {
      Debug.Log("Name: " + device);
    }
  }
  //Function that determines what to do when a keyword is heard
  private void RecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
  {
    //Output to console for debugging
    Debug.Log("Phrase recognised");
    //Storing said keyword into word variable for use in the switch statement
    word = args.text;
    //Output to console for debugging
    Debug.Log("You said: " + word);
    //Switch statement that determines what the program should do based off of the keyword input
    switch (word)
    {
      //Case that shows the level select menu
      case "start":
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        break;
      //Case that shows the options menu
      case "options":
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        break;
      //Case that closes the game
      case "exit":
        CloseRecognizer();
        ExitGame();
        break;
      //Case that returns the user back to the main menu
      case "back to menu":
          mainMenu.SetActive(true);
          optionsMenu.SetActive(false);
          levelSelect.SetActive(false);
        break;
      //Case that loads the tutorial level scene
      case "tutorial":
        if(levelSelect)
        {
          CloseRecognizer();
          TutorialScene();
        }
        //Check put in place to ensure that the level cannot be loaded without the user viewing the level selection menu
        else
        {
          Debug.Log("Not on level select menu");
        }
        break;
      //Case that loads level 1 scene
      case "level one":
        if (levelSelect)
        {
          CloseRecognizer();
          Level1Scene();
        }
        //Check put in place to ensure that the level cannot be loaded without the user viewing the level selection menu
        else
        {
          Debug.Log("Not on level select menu");
        }
        break;
      //Case that loads level 2 scene
      case "level two":
        if (levelSelect)
        {
          CloseRecognizer();
          Level2Scene();
        }
        //Check put in place to ensure that the level cannot be loaded without the user viewing the level selection menu
        else
        {
          Debug.Log("Not on level select menu");
        }
        break;
      //Case that loads level 3 scene
      case "level three":
        if (levelSelect)
        {
          CloseRecognizer();
          Level3Scene();
        }
        //Check put in place to ensure that the level cannot be loaded without the user viewing the level selection menu
        else
        {
          Debug.Log("Not on level select menu");
        }
        break;
      //Case that loads level 4 scene
      case "level four":
        if (levelSelect)
        {
          CloseRecognizer();
          Level4Scene();
        }
        //Check put in place to ensure that the level cannot be loaded without the user viewing the level selection menu
        else
        {
          Debug.Log("Not on level select menu");
        }
        break;
    }
  }
  //Function for loading tutorial level
  public void TutorialScene()
  {
    //Outputs to console for debugging
    Debug.Log("Tutorial Scene Loaded");
    //Load Tutorial Level
    SceneManager.LoadScene("TutorialLevel");
  }
  //Function for loading level 1
  public void Level1Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 1 Scene Loaded");
    //Load Level 1
    SceneManager.LoadScene("Level1");
  }
  //Function for loading level 2
  public void Level2Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 2 Scene Loaded");
    //Load Level 2
    SceneManager.LoadScene("Level2");
  }
  //Function for loading level 3
  public void Level3Scene()
  {
    Debug.Log("Level 3 Scene Loaded");
    //Load Level 3
    SceneManager.LoadScene("Level3");
  }
  //Function for loading level 4
  public void Level4Scene()
  {
    //Outputs to console for debugging
    Debug.Log("Level 4 Scene Loaded");
    //Load Level 4
    SceneManager.LoadScene("Level4");
  }
  //Function for closing the application
  public void ExitGame()
  {
    //Outputs to console for error checking
    Debug.Log("Closing Game");
    //Closes the application
    Application.Quit();
  }
  //Function used to close the phrase recognizer when it is no longer needed
  private void CloseRecognizer()
  {
    //Check to see if the recognizer isnt already closed
    if(recognizer != null && recognizer.IsRunning)
    {
      //Closes the recognizer
      recognizer.OnPhraseRecognized -= RecognizerOnPhraseRecognized;
      recognizer.Stop();
    }
  }
}
