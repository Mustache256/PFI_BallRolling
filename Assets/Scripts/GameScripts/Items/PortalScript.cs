using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
  public GameObject victoryCanvas;
  public float speed = 5;
  public Transform portal;
  public GameObject player;
  private Vector3 currentPos;
  private Vector3 targetPos;
  private Vector3 travelDirection;
  private bool moveCheck = false;

  private void Update()
  {
    if(moveCheck == true)
    {
      playerMove();
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      Debug.Log("Portal Reached");
      moveCheck = true;
      
    }
  }
  private void playerMove()
  {
    currentPos = player.transform.position;
    targetPos = portal.transform.position;
    travelDirection = targetPos - currentPos;
    if (Vector3.Distance(currentPos, targetPos) > .2f)
    {
      player.transform.Translate((travelDirection.x * speed * Time.deltaTime), (travelDirection.y * speed * Time.deltaTime), (travelDirection.z * speed * Time.deltaTime), Space.World);
    }
    else
    {
      moveCheck = false;
      victoryCanvas.SetActive(true);
      Debug.Log("Level Complete");
      Time.timeScale = 0f;
    }
  }
}
