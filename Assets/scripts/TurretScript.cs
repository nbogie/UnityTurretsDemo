using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {
	public GameObject bulletOrig;

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

	public int playerNumber;
	public string controlPrefix;

	void Start () {
		bulletAmount = 1;	
	}

	private string horizAxisName(){
		return controlPrefix + "Horizontal";
	}
	private string verticalAxisName(){
		return controlPrefix + "Vertical";
	}
	private string Fire1ButtonName(){
		return controlPrefix + "Fire1";
	}
	private string Fire2ButtonName(){
		return controlPrefix + "Fire2";
	}
	private string Fire3ButtonName(){
		return controlPrefix + "Fire3";
	}
	private string Fire4ButtonName(){
		return controlPrefix + "Fire4";
	}
	private string Fire5ButtonName(){
		return controlPrefix + "Fire5";
	}
	private string Fire6ButtonName(){
		return controlPrefix + "Fire6";
	}
	private string Fire8ButtonName(){
		return controlPrefix + "Fire8";
	}
	private string Fire9ButtonName(){
		return controlPrefix + "Fire9";
	}

	void Update () {
		//UP and DOWN: rotate turret cylinder without changing turret base (a parent)
		if (Input.GetKey(keyTurretUp) || Input.GetAxis(verticalAxisName()) < -0.1) {
			turretCylinder.transform.Rotate(Vector3.up, 5);
		}
		if (Input.GetKey(keyTurretDown) || Input.GetAxis(verticalAxisName()) > 0.1) {
			turretCylinder.transform.Rotate(Vector3.down, 5);
		}

		//LEFT and RIGHT: rotate turret base
		if (Input.GetKey(keyRotateLeft) || Input.GetAxis(horizAxisName()) < -0.1) {
			transform.Rotate(Vector3.down, 3);
		}
		if (Input.GetKey(keyRotateRight)  || Input.GetAxis(horizAxisName()) > 0.1) {
			transform.Rotate(Vector3.up, 3);
		}

		//FWD and BACK: move turret base on its right vector
		if (Input.GetKey(keyForward) || Input.GetButton(Fire6ButtonName())) {
			transform.Translate (Vector3.right *0.1f);
		}
		if (Input.GetKey(keyBack) || Input.GetButton(Fire5ButtonName())) {
			transform.Translate (-Vector3.right * 0.1f);
		}


		if (Input.GetKeyDown (keyFire) || Input.GetButtonDown(Fire1ButtonName())) {
			for (int i = 0; i < bulletAmount; i++) {
				fireBullet ();
			}
		} 
	}
	void fireBullet() {
		//https://www.youtube.com/watch?v=4rZAAHevq1s
		GameObject clone = Instantiate (bulletOrig, firingTransform.position, firingTransform.rotation);
		Rigidbody rb = clone.GetComponent<Rigidbody> ();
		float deltaTime = 1.5f;
		float power = 100 + Mathf.Min (3, deltaTime) * 300;
		rb.AddRelativeForce (Vector3.forward * power, ForceMode.Acceleration);
		clone.GetComponent<MaterialSelection> ().SetPlayer(playerNumber);

	}
}
