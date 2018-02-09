using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDoesDamage : MonoBehaviour
{

	public float amountOfDamageToDo = 6;

	void OnCollisionEnter (Collision coll)
	{
		TakeDamageScript takeDamage = coll.gameObject.GetComponent<TakeDamageScript> ();
		if (takeDamage) {
			takeDamage.TakeDamage (amountOfDamageToDo);
			Destroy (gameObject);
		}
	}

}
