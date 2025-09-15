using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{	
	private TMPro.TextMeshProUGUI text;
    void Start()
    {
	    text = GetComponent<TextMeshProUGUI>();
	    GameManager.isShoot = true;
    }
	
	private float limitTime = 30;
	private float nowTime;
	
	private float waitTime;
	public GameObject panelGameOver;
    void Update()
	{	
		nowTime = Mathf.Round(Mathf.Clamp(( limitTime - Time.time),0,60));
		text.text = nowTime.ToString();
		
		if( nowTime == 0 )
		{	
			if (waitTime >= Time.time)
			{
				panelGameOver.SetActive(true);
				GameManager.isShoot = false;
				GameManager.CurrentScore = 0;
			}
			else
			{
				panelGameOver.SetActive(false);
				GameManager.isShoot = true;
				limitTime = 30 + Time.time;
			}
		}
		else
		{
			waitTime = Time.time + 4;
		}
	}
	

	
}

