using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelection : MonoBehaviour
{

	public Material p1FinMaterial;
	public Material p2FinMaterial;
	public Material p1BodyMaterial;
	public Material p2BodyMaterial;
	private int playerNumber = 1;

	void Start ()
	{
		ColorForPlayerNumber ();
	}

	void ColorForPlayerNumber ()
	{
		Material fm = p1FinMaterial;
		Material bm = p1BodyMaterial;
		if (playerNumber == 2) {
			fm = p2FinMaterial;
			bm = p2BodyMaterial;
		}
		GetComponent<Renderer> ().material = bm;
		foreach (Transform child in transform) {
			child.GetComponent<Renderer> ().material = fm;
		}
	}

	public void SetPlayer (int n)
	{
		playerNumber = n;
		ColorForPlayerNumber ();
	}
	
}
