using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}

	public void StartGame ()
	{
		SceneManager.LoadScene ("main");
	}

	public void LoadMenuScene ()
	{
		SceneManager.LoadScene ("StartMenu");
	}

	public void LoadOptionsScene ()
	{
		SceneManager.LoadScene ("options");
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}
