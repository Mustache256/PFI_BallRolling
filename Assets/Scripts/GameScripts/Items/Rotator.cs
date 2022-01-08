using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	//Simple script that rotates teh pickups
	void Update () 
	{
		//Rotates the pickups using the vector3 below as the parameter continually
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
