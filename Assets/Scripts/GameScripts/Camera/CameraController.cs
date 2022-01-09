using UnityEngine;
using System.Collections;
//Script used for camera control and interlocking it with the player's movement
public class CameraController : MonoBehaviour 
{
	//Variable that stores the transform of the main camera so that the camera can be moved
	private Transform mainCamera;
	//Variable that stores player object information
	private PlayerController player;
	//Variable that stores the initial x rotation of the player
	private float initialXRotation;
	//Variable that stores the amount of horizontal tilt being applied to the camera
	private float horizontalTilt;
	//Variable that stores the amount of vertical tilt being applied to the camera
	private float verticalTilt;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable that stores the max angle the camera can be tilted to vertically
	private float maxVerticalAngle;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable that stores the max angle the camera can be tilted to horizontally
	private float maxHorizontalAngle;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable that stores the speed in which teh camera is tilted
	private float tiltSpeed;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable that stores the offest of the camera from the player
	private float offset;
	//Forcing private variable to appear in inspector
	[SerializeField]
	//Variable that determines whether or not to use teh floor normal from the player 
	private bool useFloorNormal;
	//Function used for setup on loading a scene
	void Start () 
	{
		//Retrieving the actual camera from the camera controller and storing it
		mainCamera = transform.GetChild(0);
		//Retrieving the player object and storing
		player = FindObjectOfType<PlayerController>();
		//Storing the initial x rotation as a reference poin tfor future calculations
		initialXRotation = transform.eulerAngles.x;
	}
	//Function called every frame at a fixed rate
  void FixedUpdate()
  {
		//Check player state to see if player can move, and therefore if camera should be able to move as well
    if(player.currentState == PlayerController.STATE.NORMAL)
    {
			//Storing both the vertical and horizontal tilt of the camera
			verticalTilt = Input.GetAxis("Vertical");
			horizontalTilt = Input.GetAxis("Horizontal");
			//Moving the player in accordance with the camera tilt
			player.Move(verticalTilt, horizontalTilt, transform.right);
    }
  }
	//Function called every frame
  void Update () 
	{
		//Checking player state to determine if the camera should be able to move
		if (player.currentState == PlayerController.STATE.NORMAL)
    {
			//Calling function that manages camera tilt
			CameraTilt();
    }
	}
	//Function that handles checking player state
  void LateUpdate()
  {
		//Switch statement that determines what to do based off of current player state
    switch(player.currentState)
    {
			case PlayerController.STATE.WAIT:
				//Calls function that starts the stage
				StartStage();
				break;
			case PlayerController.STATE.NORMAL:
				//Calls function that manages the camera following the player
				FollowTarget();
				break;
			case PlayerController.STATE.DEAD:
				//Makes the camera look at the paleyr as it falls off the map
				transform.LookAt(player.transform.position);
				break;
    }
  }
	//Function that starts the stage
	void StartStage()
  {
		//Sets player state to normal as stage has started
		player.currentState = PlayerController.STATE.NORMAL;
  }
	//Function that manages camera tilt
	void CameraTilt()
  {
		//Tilts the camera container along the x axis forwards and backwards giving the tilting effect, with the use of a joystick being able to control how far the camera will tilt
		float scaledVerticalTilt = initialXRotation - (verticalTilt * maxVerticalAngle);

		//Making use of the floor normal to adjust the rotation of the camera's x axis at rest
		float angleBetweenFloorNormal = useFloorNormal ? Vector3.SignedAngle(Vector3.up, player.floorNormal, transform.right) : 0.0f;

		Quaternion targetXRotation = Quaternion.Euler(scaledVerticalTilt + angleBetweenFloorNormal, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetXRotation, tiltSpeed * Time.deltaTime);

		//Rotate teh camera along the z axis to give the camera the left and right tiltiong effect, again with teh angle being able to be controlled via the use of a joystick
		float scaledHorizontalTilt = Input.GetAxis("Horizontal") * maxHorizontalAngle;

		Quaternion targetZRotation = Quaternion.Euler(mainCamera.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, scaledHorizontalTilt);

		mainCamera.rotation = Quaternion.RotateTowards(mainCamera.rotation, targetZRotation, tiltSpeed * Time.deltaTime);
  }
	//Function that causes the camera to follow the player
	void FollowTarget()
  {
		//Get a forward vector minus the y component
		Vector3 vectorA = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
		//Get the player's velocity minus the y component
		Vector3 vectorB = new Vector3(player.rb.velocity.x, 0.0f, player.rb.velocity.z);
		//Find the angle between vectorA and vectorB
		float rotateAngle = Vector3.SignedAngle(vectorA.normalized, vectorB.normalized, Vector3.up);
		//Get the player's speed (magnitude) without the y component, with the speedFactor variable only being set when vectorA and vectorB are almost facing the same direction
		float speedFactor = Vector3.Dot(vectorA, vectorB) > 0.0f ? vectorB.magnitude : 1.0f;

		//Rotate the camera towards the angle between vector A and B, making use of speedFactor so tha the camera doesn't rotate at a constant speed, but also limit speedFactor between 1 and 2 
		transform.Rotate(Vector3.up, rotateAngle * Mathf.Clamp(speedFactor, 1.0f, 2.0f) * Time.deltaTime);

		//Position the camera behind the player at a distance of offset
		transform.position = player.transform.position - (transform.forward * offset);
		transform.LookAt(player.transform.position);
  }
}
