﻿using UnityEngine;

public class GizmoScript : MonoBehaviour {

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, 0.1f);
	}
}
