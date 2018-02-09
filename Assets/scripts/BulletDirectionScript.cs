using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirectionScript : MonoBehaviour {
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {

		//face in direction of travel, if moving fast enough
		Vector3 vel = rb.velocity;
		if (vel.sqrMagnitude > 4) {			
			transform.rotation = Quaternion.LookRotation (vel.normalized);
		}

	}
}
