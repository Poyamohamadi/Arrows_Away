using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{	
	private float currentRotation = 0;
    void Update()
	{
		currentRotation = 
		(Input.GetAxisRaw("Mouse Y") * (400f * Time.deltaTime) * -1)
			+ currentRotation;
		
		currentRotation = Mathf.Clamp(currentRotation, -50, 50);
		
		transform.rotation = Quaternion.Euler(new Vector3(currentRotation,0,0));
	}
}
