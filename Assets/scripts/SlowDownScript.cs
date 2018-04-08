using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownScript : MonoBehaviour
{

	void Update ()
	{
		if (Input.GetKey (KeyCode.Alpha1)) {
			Time.timeScale = 0.2f;
		} else {
			Time.timeScale = 1;
		}
		
	}
}
