using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script that manages the end portal of levels
public class PortalScript : MonoBehaviour
{
  //Variable that stores the canvas that is displayed upon the player completing a level
  public GameObject victoryCanvas;
  //Variable that stores the speed at which the player is pulled into the portal
  public float speed = 5;
  //Varaibel that stores the position of the center of the portal
  public Transform portal;
  //Variable that stores the player object
  public GameObject player;
  //Variable that stores player's current position upon entering the portal
  private Vector3 currentPos;
  //Variable that stores the position that player will move to
  private Vector3 targetPos;
  //Variable that stores player travel direction
  private Vector3 travelDirection;
  //Variable that stores whether or not the player need to move
  private bool moveCheck = false;
  //Function called every frame
  private void Update()
  {
    //Checking to see if player needs to move
    if(moveCheck == true)
    {
      //Calling player move function
      playerMove();
    }
  }
  //Function that checks for collisions with the portal to determine if the player has collided with it
  private void OnTriggerEnter(Collider other)
  {
    //Checking to see if collision occured with player object
    if(other.gameObject.tag == "Player")
    {
      //Output to console for debugging
      Debug.Log("Portal Reached");
      //Setting move check bool to true
      moveCheck = true;
    }
  }
  //Function that handles moving the player into the center of the portal
  private void playerMove()
  {
    //Getting player current position and storing it
    currentPos = player.transform.position;
    //Getting target position from portal center
    targetPos = portal.transform.position;
    //Calculating direction vector
    travelDirection = targetPos - currentPos;
    //Check to see if the distance between the 2 points is low enough to end the level
    if (Vector3.Distance(currentPos, targetPos) > .2f)
    {
      //Translate function to move the player to the center of the portal
      player.transform.Translate((travelDirection.x * speed * Time.deltaTime), (travelDirection.y * speed * Time.deltaTime), (travelDirection.z * speed * Time.deltaTime), Space.World);
    }
    //Else statement to end the level if player is in the center of the portal
    else
    {
      //Setting move check to false
      moveCheck = false;
      //Displaying the victoy canvas to the player
      victoryCanvas.SetActive(true);
      //Output to cansole for debugging
      Debug.Log("Level Complete");
      //Pausing the scene as the level has ended
      Time.timeScale = 0f;
    }
  }
}
