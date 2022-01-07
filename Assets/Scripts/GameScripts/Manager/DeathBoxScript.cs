using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxScript : MonoBehaviour
{
  private PlayerController player;
  public Transform deathHeight;
  // Start is called before the first frame update
  void Start()
  {
    player = FindObjectOfType<PlayerController>();
    
  }

  // Update is called once per frame
  void Update()
  {
        
  }
  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      player.currentState = PlayerController.STATE.DEAD;
      waitAndReset();
      SceneManager.LoadScene("TutorialLevel");
    }
  }
  IEnumerator waitAndReset()
  {
    yield return new WaitForSeconds(3);
  }
}
