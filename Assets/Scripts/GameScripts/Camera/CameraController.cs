using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	private PlayerController player;

	private float initialXRotation;

	private float horizontalTilt;
	private float verticalTilt;

	private Transform mainCamera;
	private Vector3 offset;

	void Start () 
	{
		mainCamera = transform.GetChild(0);
		player = FindObjectOfType<PlayerController>();
		offset = transform.position;

		initialXRotation = transform.eulerAngles.x;
	}
	
	void Update () 
	{
		transform.position = player.transform.position + offset;
	}
}
