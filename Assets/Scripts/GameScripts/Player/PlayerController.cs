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

	public float speed;
  public Rigidbody orientation;
  public Rigidbody spawnPoint;
	public Rigidbody rb;
	public float maxSpeed;
	public STATE currentState;
	public Vector3 floorNormal;

	
	private LayerMask whatIsGround;
	private float groundCheckRadius;
	private float moveForce;
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

  private void Update()
  {
		
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
  
	void OnTriggerEnter(Collider other) 
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
	}

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
	
	/*void Update()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed * Time.deltaTime);

		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}

		orientation.transform.position = rb.position;
	}*/
}
