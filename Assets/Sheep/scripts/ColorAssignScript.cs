using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssignScript : MonoBehaviour
{

	public Material normalMaterial;
	public Material rareMaterial;

	void Start ()
	{
		Material m;
		if (Random.value > 0.93) {
			m = rareMaterial;
		} else {
			m = normalMaterial;
		}
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material = m;
	}
	

}
