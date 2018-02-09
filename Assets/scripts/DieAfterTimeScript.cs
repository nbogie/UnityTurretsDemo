using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTimeScript : MonoBehaviour {
	void Start () {
		Destroy (gameObject, 10);	
	}	
}
