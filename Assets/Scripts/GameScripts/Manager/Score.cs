using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script used to manage and track player score for current level
public class Score : MonoBehaviour
{
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
    //Setting score to 0 on load
    score = 0;
    //Setting GUI text showing score to show 0 on load
    scoreText.text = "Score: " + 0;
  }

  //Function used to set the current score the player has
  public void setScore(int scoreToAdd)
  {
    //Adding to score based off of input variable into funciton
    score += scoreToAdd;
    //Showing curren tscore within GUI
    scoreText.text = "Score: " + score.ToString();
    //Changing final score text on victory screen
    finalScore.text = score.ToString();
  }
  //Function to get current player score
  public int getScore()
  {
    //Returns Current Score
    return score;
  }
}
