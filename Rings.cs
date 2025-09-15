using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
	public GameObject effectBurst;
	public int point;
    protected void OnCollisionEnter(Collision collisionInfo)
	{
		Instantiate(effectBurst,transform.position,Quaternion.identity);
		GameManager.CurrentScore = point + GameManager.CurrentScore;
	}
}
