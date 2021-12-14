using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public Rigidbody rb;
    public Rigidbody orientation;
    public Rigidbody spawnPoint;
    public float maxSpeed;
	
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	void Update ()
	{
        

        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed * Time.deltaTime);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        orientation.transform.position = rb.position;
    }
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "PickUp")
        {
			other.gameObject.SetActive (false);
		}
        else if (other.gameObject.tag == "DontPickUp")
        {
			other.gameObject.SetActive (false);
		}
        else if(other.gameObject.tag == "DeathBox")
        {
            rb.transform.position = spawnPoint.position;
        }
	}
}
