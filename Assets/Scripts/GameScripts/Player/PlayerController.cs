using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Script used to manage and control player movemnet, state and other aspects that are interlinked with the camera in order to created the desired camera effect
public class PlayerController : MonoBehaviour 
{	
	//Enum used to store player state for use by both the player and camera
	public enum STATE
  {
		WAIT,
		NORMAL,
		DEAD,
		STATES
  }
	public GameObject sceneManager;
	//Hiding public variable from inspector
	[HideInInspector]
	//Variable used to store player state
	public STATE currentState;
	//Hiding public variable from inspector
	[HideInInspector]
	//Variable to store rigidbody component of player
	public Rigidbody rb;
	//Hiding public variable from inspector
	[HideInInspector]
	//Variable used to store vector of the normal that is perpendicular to the floor
	public Vector3 floorNormal;

	//Variable that stores max player speed
	public float maxSpeed;

	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable used to store the radius around the player of which objects within will be checked to determine if they're part of the level's ground
	private float groundCheckRadius;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable used to store the amount of force that will be applied to the player when moving
	private float moveForce;
	//Forcing private variable to appear in inspector
	[SerializeField]
	private LayerMask whatIsGround;
	
	//Function used for setup on loading a scene
	void Start()
	{
		//Retrieving rigidbody component from player
		rb = gameObject.GetComponent<Rigidbody> ();
		//Setting player state to WAIT
		currentState = STATE.WAIT;
	}
	//Function used for making the player move
  public void Move(float verticalTilt, float horizontalTilt, Vector3 right)
  {
		//Checking if the player is grounded to prevent mid-air movement
		if (OnGround())
    {
			//Calling function used to calculate the normal from the floor
			CalculateFloorNormal();
			//Check to see if there is any camera movement to determine if there is player input, and then do something if the player object is moving
			if (horizontalTilt == 0.0f && verticalTilt == 0.0f && rb.velocity.magnitude > 0.0f)
      {
				//Lerp used to slow player object movement to 0 if no input is detected from the player
				rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, moveForce * 0.1f * Time.deltaTime);
      }
			//Do this if there is player input
      else
      {
				//Retrieving the direction that is perpendicular to the camera's right vector and the floor's normal (this direction being forward)
				Vector3 forward = Vector3.Cross(right, floorNormal);

				//Apply force to move the player, with the force applied scaling based upon how far the camera is tilted vertically, giving the player control over the amount of speed applied (The applied force is halved when the player is moving backwards)
				Vector3 forwardForce = (verticalTilt > 0.0f ? 1.0f : 0.5f) * moveForce * verticalTilt * forward;
				//Apllies for to the player in the right direction scaled in accordance with the horizontal tilt of the camera
				Vector3 rightForce = moveForce * horizontalTilt * right;
				//Calculation of vector to apply to the player based off of previous calculations, determining exactly which direction the player needs to move in and how much force to apply to the player 
				Vector3 forceVector = forwardForce + rightForce;
				//Applying calculated vector to the player's rigidbody
				rb.AddForce(forceVector);
      }
    }
  }
  //Function used to check if the player is on the level's ground
	public bool OnGround()
  {
		//Checking all objects within a sphere around the player object to determine if any of said objects are within the ground layer of the scene, and returning said result (either true or false) 
	  return Physics.CheckSphere(transform.position - (Vector3.up * 0.5f), groundCheckRadius, whatIsGround);
  }
	//Function used to calculate teh floor normal
	private void CalculateFloorNormal()
  {
		//Raycast fired directly below the player, which can act as teh floor normal
		RaycastHit hit;
		//Chewcking to see if the ray hits an object that is within the floor layer of the scene
		if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, whatIsGround))
    {
			//Setting the floor normal have the same properties as the cast ray
			floorNormal = hit.normal;
    }
  }
	//Function that detects collision with other objects (used to detect item pickups)
	private void OnTriggerEnter(Collider other)
  {
		//Ckeck to see if other item tag is pickup
		if (other.gameObject.tag == "PickUp")
		{
			//Adding 1 to the score when the pickup is collected by the player
			sceneManager.GetComponent<Score>().setScore(1);
			//Output to console for debugging
			Debug.Log("Pickup Collected");
			//Destroying the pickup as it is collected by the player
			Destroy(other.gameObject);
		}
  }
}
