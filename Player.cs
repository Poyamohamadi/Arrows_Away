using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{	
	private Rigidbody rb;

	protected void Start()
	{	
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
		rb = GetComponent<Rigidbody>();
	}

	protected void FixedUpdate()
	{
		rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"),rb.velocity.y,0)* 6 ;
		
	}
}
