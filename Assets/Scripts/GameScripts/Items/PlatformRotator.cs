using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    //Simple script that rotates a level platform
    void Update()
    {
    //Rotates platform around its y axis continually
    transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
    }
}
