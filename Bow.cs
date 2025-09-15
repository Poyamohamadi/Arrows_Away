using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
	public GameObject Arrow;
	public GameObject mainCamera; 
	private GameObject ArrowInstance;
	
	private float fireRate = 0.2f;
	private float nextFireTime = 0f;
	
	private bool IsDecreasing = false;
	
	protected void Update()
	{
		if ( Input.GetButton("Fire1") && Time.time >= nextFireTime && IsDecreasing == false 
			&& GameManager.isShoot )
		{
			nextFireTime = Time.time + fireRate;
			GameManager.power = 
				Mathf.Clamp(GameManager.power + Time.deltaTime + 0.15f,
				0, 1);
			if ( GameManager.power == 1 )
			{
				IsDecreasing = true;
			}
		}
		else if ( Input.GetButton("Fire1") && Time.time >= nextFireTime && IsDecreasing )
		{
			nextFireTime = Time.time + fireRate;
			GameManager.power = 
				Mathf.Clamp(GameManager.power - Time.deltaTime - 0.15f,
				0, 1);
			if ( GameManager.power == 0 )
			{
				IsDecreasing = false;
			}	
		}
		
	
		if ( Input.GetButtonUp("Fire1") && ArrowInstance == null && GameManager.isShoot )
		{
			ArrowInstance = Instantiate(Arrow, transform.position, mainCamera.transform.rotation); 
		}
	}
}
