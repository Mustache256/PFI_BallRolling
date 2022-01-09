using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
//Script used for managing speech recognition controls of the main menu
public class SpeechRecognition : MonoBehaviour
{
  //Variables used to store the menu objects, so they can be used by the script to allow the player to use speech to control the menu
  public GameObject mainMenu, optionsMenu, levelSelect, sceneManagement;
  //Keywords string used by the PhraseRecognizer as an index for what commands to listen for
  public string[] keywords = new string[] { "start", "options", "exit", "back to menu", "tutorial", "level one", "level two", "level three", "level four" };
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
    switch(word)
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
      case "exit":
        break;
      case "back to menu":
        break;
      case "tutorial":
        break;
      case "level one":
        break;
      case "level two":
        break;
      case "level three":
        break;
      case "level four":
        break;
    }
  }
}
