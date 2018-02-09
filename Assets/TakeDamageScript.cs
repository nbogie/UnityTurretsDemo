using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageScript : MonoBehaviour
{

	public float health = 10;

	void Start ()
	{
		health = 10;
	}

	public void TakeDamage (float dmgAmount)
	{
		health -= dmgAmount;
		if (health < 0) {
			Destroy (gameObject);
		}
	}

}
