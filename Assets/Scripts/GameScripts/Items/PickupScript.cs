using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
  public GameObject sceneManager;
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      sceneManager.GetComponent<LevelManager>().setScore(1);
      Debug.Log("Pickup Collected");
      Destroy(this.gameObject);
    }
  }
}
