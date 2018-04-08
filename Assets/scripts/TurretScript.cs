using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public enum ControlSet { LeftCluster, RightCluster};

    public ControlSet controlSet;
    private Animator animator;

	[Range (1, 10)]
	public int bulletAmount;

    [Header("Wiring")]
    public GameObject bulletPrefab;
    public Transform firingTransform;
	public GameObject turretCylinder;
    private GameObject projectilesParent;

    [Header("Control Keys")]
	public KeyCode keyTurretUp;
	public KeyCode keyTurretDown;
	public KeyCode keyRotateLeft;
	public KeyCode keyRotateRight;
	public KeyCode keyForward;
	public KeyCode keyBack;
	public KeyCode keyFire;

	public int playerNumber;
	public string controlPrefix;

	void Start ()
	{
        animator = GetComponent<Animator>();
        projectilesParent = GameObject.Find("Projectiles");
        bulletAmount = 1;
	}

	private string horizAxisName ()
	{
		return controlPrefix + "Horizontal";
	}

	private string verticalAxisName ()
	{
		return controlPrefix + "Vertical";
	}

    bool PlayerButtonDown(string suffix)
    {
        return Input.GetButtonDown(controlPrefix + suffix);
    }
    bool PlayerButtonUp(string suffix)
    {
        return Input.GetButtonUp(controlPrefix + suffix);
    }

	void Update ()
	{
		//UP and DOWN: rotate turret cylinder without changing turret base (a parent)
		if (Input.GetKey (keyTurretUp) || Input.GetAxis (verticalAxisName ()) < -0.1) {
			turretCylinder.transform.Rotate (Vector3.up, 5);
		}
		if (Input.GetKey (keyTurretDown) || Input.GetAxis (verticalAxisName ()) > 0.1) {
			turretCylinder.transform.Rotate (Vector3.down, 5);
		}

		//LEFT and RIGHT: rotate turret base
		if (Input.GetKey (keyRotateLeft) || Input.GetAxis (horizAxisName ()) < -0.1) {
			transform.Rotate (Vector3.down, 3);
		}
		if (Input.GetKey (keyRotateRight) || Input.GetAxis (horizAxisName ()) > 0.1) {
			transform.Rotate (Vector3.up, 3);
		}
        if (Input.GetKeyDown(keyFire) || PlayerButtonDown("Fire1"))
        {
            animator.SetBool("isFiring", true);
        }
        if (Input.GetKeyUp(keyFire) || PlayerButtonUp("Fire1"))
        {
            animator.SetBool("isFiring", false);

        }


	}

	void FixedUpdate ()
	{
		//FWD and BACK: move turret base on its right vector
		if (Input.GetKey (keyForward) || PlayerButtonDown ("Fire6")) {
			TryToTranslate (Vector3.right * 5);
				
		}
		if (Input.GetKey (keyBack) || PlayerButtonDown ("Fire5")) {
			TryToTranslate (-Vector3.right * 5);
		}


	}

	void TryToTranslate (Vector3 offset)
	{
		transform.Translate (offset * Time.deltaTime);

	}

	void FireBullet ()
	{
		//https://www.youtube.com/watch?v=4rZAAHevq1s
		GameObject clone = Instantiate (bulletPrefab, firingTransform.position, 
                                        firingTransform.rotation, 
                                        projectilesParent.transform);
		Rigidbody bulletRB = clone.GetComponent<Rigidbody> ();
		float deltaTime = 1.5f;
		float power = 100 + Mathf.Min (3, deltaTime) * 300;
		bulletRB.AddRelativeForce (Vector3.forward * power, ForceMode.Acceleration);
		clone.GetComponent<MaterialSelection>().SetPlayerNumber (playerNumber);

	}
}
