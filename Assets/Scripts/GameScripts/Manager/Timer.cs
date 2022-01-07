using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public GameObject timeOutCanvas;
  public GameObject sceneManager;
  private int score;
  private bool timerIsRunning;
  [SerializeField]
  private Text timerText;
  [SerializeField]
  private Text finalTime;
  [SerializeField]
  private Text finalTimeOut;
  [SerializeField]
  private Text finalScoreOut;

  public float timeRemaining;
  private void Start()
  {
    timeOutCanvas.SetActive(false);
    timerIsRunning = true;
    timerText.text = "Time: " + timeRemaining.ToString("f2");
  }
  // Update is called once per frame
  void Update()
  {
    if(timerIsRunning)
    {
      if (timeRemaining > 0)
      {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + timeRemaining.ToString("f2");
        finalTime.text = timeRemaining.ToString("f2");
      }
      else
      {
        Debug.Log("Time has run out");
        timeRemaining = 0;
        finalTimeOut.text = timeRemaining.ToString("f2");
        score = sceneManager.GetComponent<LevelManager>().getScore();
        finalScoreOut.text = score.ToString();
        timerIsRunning = false;
        timeOutCanvas.SetActive(true);
        Time.timeScale = 0f;
      }
    }
  }
}
