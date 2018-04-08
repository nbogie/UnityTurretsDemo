using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionDoesDamage : MonoBehaviour
{
    public GameObject fragPSysPrefab;

    GameObject projectilesParent;
	
    public float amountOfDamageToDo = 6;
	void Start()
	{
        projectilesParent = GameObject.Find("Projectiles");
        if(!projectilesParent){
            Debug.LogError("missing Projectiles empty in scene");
        }
	}

	void OnCollisionEnter (Collision coll)
	{
		TakeDamageScript takeDamage = coll.gameObject.GetComponent<TakeDamageScript> ();
		if (takeDamage) {
			takeDamage.TakeDamage (amountOfDamageToDo);
            GameObject psys = Instantiate(fragPSysPrefab, transform.position, 
                                          Quaternion.identity, projectilesParent.transform);
            Destroy(psys, 3f);
            Destroy (gameObject);
		}
	}

}
