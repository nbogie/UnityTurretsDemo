using UnityEngine;

public class TrackerTurret : MonoBehaviour
{
    private GameObject target;

    public GameObject partToRotate;
    public float turnSpeed = 2;

    private GameObject targetsContainer;

    void Start()
    {
        targetsContainer = GameObject.Find("Mobs");
        InvokeRepeating("FireIfTarget", 1f, 4f);
    }

    void TurnImmediatelyTowards(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 eulerLookRotation = lookRotation.eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, eulerLookRotation.y, 0f);
    }

    void TurnGraduallyTowards(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f, rot.y, 0f);
    }
    GameObject FindNearestTarget(){
        float nearestDistance = float.PositiveInfinity;
        GameObject nearest = null;

        foreach(Transform t in targetsContainer.transform){
            float d = Vector3.Distance(t.position, transform.position);
            if (d < nearestDistance){
                nearest = t.gameObject;
                nearestDistance = d;
            }    
        }
        return nearest;
    }
    void Update()
    {
        target = FindNearestTarget();
        if (target){
            TurnGraduallyTowards(target.transform.position);
        }

    }
    void Fire(){
        
    }
    void FireIfTarget(){
        if(target){
            Fire();
        }
    }
}
