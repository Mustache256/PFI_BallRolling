using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
  public GameObject SceneManager;
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      SceneManager.GetComponent<LevelManager>().setScore(1);
      Debug.Log("Pickup Collected");
      Destroy(this.gameObject);
    }
  }
}
