using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
	private UnityEngine.UI.Slider slider;
 
    void Start()
    {
	    slider = GetComponent<UnityEngine.UI.Slider>();
    }

    void Update()
    {
	    slider.value = GameManager.power;
    }
}
