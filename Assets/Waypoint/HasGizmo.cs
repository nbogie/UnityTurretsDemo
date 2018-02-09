using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasGizmo : MonoBehaviour
{


	void OnDrawGizmos ()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position, 0.5f);
	}
}
