using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{	
	public enum STATE
  {
		WAIT,
		NORMAL,
		DEAD,
		VICTORY,
		STATES
  }
	[HideInInspector]
	public STATE currentState;
	[HideInInspector]
	public Rigidbody rb;
	[HideInInspector]
	public Vector3 floorNormal;

	public float maxSpeed;
	
	[SerializeField]
	private float groundCheckRadius;
	[SerializeField]
	private float moveForce;
	[SerializeField]
	private LayerMask whatIsGround;
	
	
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();

		currentState = STATE.WAIT;
	}

  void FixedUpdate()
  {
		Debug.Log("Player Current State: " + currentState);
		switch (currentState)
    {
			case STATE.VICTORY:
				break;
    }
	}

  public void Move(float verticalTilt, float horizontalTilt, Vector3 right)
  {
		if (OnGround())
    {
			CalculateFloorNormal();

			if (horizontalTilt == 0.0f && verticalTilt == 0.0f && rb.velocity.magnitude > 0.0f)
      {
				rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, moveForce * 0.1f * Time.deltaTime);
      }
      else
      {
				Vector3 forward = Vector3.Cross(right, floorNormal);

				Vector3 forwardForce = (verticalTilt > 0.0f ? 1.0f : 0.5f) * moveForce * verticalTilt * forward;

				Vector3 rightForce = moveForce * horizontalTilt * right;

				Vector3 forceVector = forwardForce + rightForce;

				rb.AddForce(forceVector);
      }
    }
  }
  
	/*void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
		}
		else if (other.gameObject.tag == "DontPickUp")
		{
			other.gameObject.SetActive(false);
		}
		else if (other.gameObject.tag == "DeathBox")
		{
			rb.transform.position = spawnPoint.position;
		}
	}*/

	public bool OnGround()
  {
	  return Physics.CheckSphere(transform.position - (Vector3.up * 0.5f), groundCheckRadius, whatIsGround);
  }

	private void CalculateFloorNormal()
  {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, whatIsGround))
    {
			floorNormal = hit.normal;
    }
  }
}
