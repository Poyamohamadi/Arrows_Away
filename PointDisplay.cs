using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
	private TextMeshProUGUI ScoreText;
	
	void Start()
	{
		ScoreText = GetComponent<TextMeshProUGUI>();
	}
    void Update()
	{
		ScoreText.text = GameManager.CurrentScore.ToString();
    }
}
