using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script used to manage level timer and said timer being displayed to the player via GUI
public class Timer : MonoBehaviour
{
  //Varialbe used to store canvas that appears when teh player runs out of time to complete a level
  public GameObject timeOutCanvas;
  //Variable used to store the scene manager
  public GameObject sceneManager;
  //Variable used to store player score
  private int score;
  //Variable used to determine whether the timer is running or not
  private bool timerIsRunning;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Variable that stores the text used to show the timer to the player
  private Text timerText;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Variable that stores the text used to show the time the player had left upon completing a level
  private Text finalTime;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Variable used to store the text the shows the player how much time they had left on a timeout
  private Text finalTimeOut;
  //Forcing private variable to be visible in the inspector
  [SerializeField]
  //Varaible used to store the text that shows the player how much score they had when they timed out
  private Text finalScoreOut;
  //Vairable that stores the amount of time the player has left to complete a level
  public float timeRemaining;
  //Function used for setup on loading a scene
  private void Start()
  {
    //Setting score store variable to 0 by default
    score = 0;
    //Set canvas that appears on timeout to false to hide it by default
    timeOutCanvas.SetActive(false);
    //Set timer running tracker bool to true
    timerIsRunning = true;
    //Setting timer GUI text to show the initial time
    timerText.text = "Time: " + timeRemaining.ToString("f2");
    //Check to see if the timer is runniong
    if(timerIsRunning)
    {
      //Output to console for debugging
      Debug.Log("Timer has started");
    }
  }
  //Function called every frame
  void Update()
  {
    //Check to see if the timer is running
    if(timerIsRunning)
    {
      //Check to see if the player has time left
      if (timeRemaining > 0)
      {
        //Reducing total time left every second
        timeRemaining -= Time.deltaTime;
        //Updating GUI text 
        timerText.text = "Time: " + timeRemaining.ToString("f2");
        //Updating victory canvas text to show how much time the player had left
        finalTime.text = timeRemaining.ToString("f2");
      }
      //Else do this if player has run out of time
      else
      {
        //Output to consoel for debugging
        Debug.Log("Time has run out");
        //Setting time remaining to be 0
        timeRemaining = 0;
        //Updating timeout final time canvas text
        finalTimeOut.text = timeRemaining.ToString("f2");
        //Retrieving player score and storing it
        score = sceneManager.GetComponent<LevelManager>().getScore();
        //Updating timeout final score canvas text
        finalScoreOut.text = score.ToString();
        //Set timer running bool to false
        timerIsRunning = false;
        //Displaying timeout canvas
        timeOutCanvas.SetActive(true);
        //Pausing the scene
        Time.timeScale = 0f;
      }
    }
  }
}
