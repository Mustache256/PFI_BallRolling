using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private bool timerIsRunning;
  [SerializeField]
  private Text timerText;

  public float timeRemaining = 60.0f;
  private void Start()
  {
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
      }
      else
      {
        Debug.Log("Time has run out");
        timeRemaining = 0;
        timerIsRunning = false;
      }
    }
  }
}
