using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
	public Rigidbody bulletOrig;

	[Range(1, 10)]
	public int bulletAmount;
	public Transform firingTransform;
	public GameObject turretCylinder;

	public KeyCode keyTurretUp;
	public KeyCode keyTurretDown;
	public KeyCode keyRotateLeft;
	public KeyCode keyRotateRight;
	public KeyCode keyForward;
	public KeyCode keyBack;
	public KeyCode keyFire;

	void Start () {
		bulletAmount = 1;	
	}


	void Update () {
		//UP and DOWN: rotate turret cylinder without changing turret base (a parent)
		if (Input.GetKey(keyTurretUp)) {
			turretCylinder.transform.Rotate(Vector3.up, 5);
		}
		if (Input.GetKey(keyTurretDown)) {
			turretCylinder.transform.Rotate(Vector3.down, 5);
		}

		//LEFT and RIGHT: rotate turret base
		if (Input.GetKey(keyRotateLeft)) {
			transform.Rotate(Vector3.down, 3);
		}
		if (Input.GetKey(keyRotateRight)) {
			transform.Rotate(Vector3.up, 3);
		}

		//FWD and BACK: move turret base on its right vector
		if (Input.GetKey(keyForward)) {			
			transform.Translate (Vector3.right *0.1f);
		}
		if (Input.GetKey(keyBack)) {
			transform.Translate (-Vector3.right * 0.1f);
		}

		if (Input.GetKeyDown (keyFire)) {		
			for (int i = 0; i < bulletAmount; i++) {
				fireBullet ();
			}
		} 
	}
	void fireBullet() {
		//https://www.youtube.com/watch?v=4rZAAHevq1s
		Rigidbody clone = Instantiate (bulletOrig, firingTransform.position, firingTransform.rotation) as Rigidbody;
		float deltaTime = 1.5f;
		float power = 100 + Mathf.Min (3, deltaTime) * 300;
		clone.AddRelativeForce (Vector3.forward * power, ForceMode.Acceleration);
	}
}
