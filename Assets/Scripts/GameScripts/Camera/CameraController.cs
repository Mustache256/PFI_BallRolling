using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	

	private Transform mainCamera;

	private PlayerController player;

	private float initialXRotation;
	private float horizontalTilt;
	private float verticalTilt;

	[SerializeField]
	private float maxVerticalAngle;
	[SerializeField]
	private float maxHorizontalAngle;
	[SerializeField]
	private float tiltSpeed;
	[SerializeField]
	private float offset;

	[SerializeField]
	private bool useFloorNormal;

	void Start () 
	{
		mainCamera = transform.GetChild(0);
		player = FindObjectOfType<PlayerController>();

		initialXRotation = transform.eulerAngles.x;
	}

  void FixedUpdate()
  {
    if(player.currentState == PlayerController.STATE.NORMAL)
    {
			verticalTilt = Input.GetAxis("Vertical");
			horizontalTilt = Input.GetAxis("Horizontal");

			player.Move(verticalTilt, horizontalTilt, transform.right);
    }
  }
  void Update () 
	{
		if (player.currentState == PlayerController.STATE.NORMAL)
    {
			CameraTilt();
    }
	}

  void LateUpdate()
  {
    switch(player.currentState)
    {
			case PlayerController.STATE.WAIT:
				StartStage();
				break;
			case PlayerController.STATE.NORMAL:
				FollowTarget();
				break;
			case PlayerController.STATE.DEAD:
				transform.LookAt(player.transform.position);
				break;
    }
  }

	void StartStage()
  {
		player.currentState = PlayerController.STATE.NORMAL;
  }

	void CameraTilt()
  {
		float scaledVerticalTilt = initialXRotation - (verticalTilt * maxVerticalAngle);

		float angleBetweenFloorNormal = useFloorNormal ? Vector3.SignedAngle(Vector3.up, player.floorNormal, transform.right) : 0.0f;

		Quaternion targetXRotation = Quaternion.Euler(scaledVerticalTilt + angleBetweenFloorNormal, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetXRotation, tiltSpeed * Time.deltaTime);


		float scaledHorizontalTilt = Input.GetAxis("Horizontal") * maxHorizontalAngle;

		Quaternion targetZRotation = Quaternion.Euler(mainCamera.rotation.eulerAngles.x, mainCamera.rotation.eulerAngles.y, scaledHorizontalTilt);

		mainCamera.rotation = Quaternion.RotateTowards(mainCamera.rotation, targetZRotation, tiltSpeed * Time.deltaTime);
  }

	void FollowTarget()
  {
		Vector3 vectorA = new Vector3(transform.forward.x, 0.0f, transform.forward.z);

		Vector3 vectorB = new Vector3(player.rb.velocity.x, 0.0f, player.rb.velocity.z);

		float rotateAngle = Vector3.SignedAngle(vectorA.normalized, vectorB.normalized, Vector3.up);

		float speedFactor = Vector3.Dot(vectorA, vectorB) > 0.0f ? vectorB.magnitude : 1.0f;

		transform.Rotate(Vector3.up, rotateAngle * Mathf.Clamp(speedFactor, 1.0f, 2.0f) * Time.deltaTime);

		transform.position = player.transform.position - (transform.forward * offset);
		transform.LookAt(player.transform.position);
  }
}
