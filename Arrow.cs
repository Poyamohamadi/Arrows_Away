using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{	
	Rigidbody rb ;
   
    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    // rb.AddForce(new Vector3(0, 0, 100)); for World axis
	    rb.AddRelativeForce(new Vector3(0, 0, 1500)*GameManager.power); // for Self axis
	    
	    
    }
    
	protected void OnCollisionEnter(Collision collisionInfo)
	{
		Destroy(this.gameObject);
		GameManager.power = 0;
	}
	
	protected void FixedUpdate()
	{
		if ( rb.velocity == new Vector3(0, 0, 0))
		{ 
			return;
		}
		else
		{
			transform.rotation = Quaternion.LookRotation(rb.velocity);
		}
	}
}
