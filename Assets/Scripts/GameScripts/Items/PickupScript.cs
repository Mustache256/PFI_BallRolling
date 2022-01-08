using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script that manages pickups and player interaction with pickups
public class PickupScript : MonoBehaviour
{
  //Variable that stores scene manager
  public GameObject sceneManager;
  //Function that detects collision with the pickup
  private void OnTriggerEnter(Collider other)
  {
    //Check to see if collision occured with the player
    if(other.gameObject.tag == "Player")
    {
      //Adding 1 to the score when the pickup is collected by the player
      sceneManager.GetComponent<LevelManager>().setScore(1);
      //Output to console for debugging
      Debug.Log("Pickup Collected");
      //Destroying the pickup as it is collected by the player
      Destroy(this.gameObject);
    }
  }
}
