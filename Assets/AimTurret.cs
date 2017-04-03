using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script used to make the turret aim and lock on to a target
public class AimTurret : MonoBehaviour {

    private Transform target; //Used to store the current target
    public float range = 20f; //Default Range off turrets
    public string AiTag = "AI";
    public Transform RotationPoint;
    public float FireRate = 1f;
    private float FireTime = 0f;
    public GameObject Bullet;
    public Transform PointOfFire;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.25f); // starts searching within 0 seconds and repeats every 0.25 seconds
	}

    void UpdateTarget()//Does a renewed search for a target
    {
        GameObject[] AIs = GameObject.FindGameObjectsWithTag(AiTag); //tags used to mark the enemy
        float MinDistance = Mathf.Infinity;
        GameObject ClosestAI = null;
        foreach (GameObject AI in AIs)
        {
            float AiDistance = Vector3.Distance(transform.position, AI.transform.position);
            if (AiDistance < MinDistance)
            {
                MinDistance = AiDistance;
                ClosestAI = AI;
            }
        }
        if (ClosestAI != null && MinDistance <= range)
        {
            target = ClosestAI.transform;
        }
        else
        {
            target = null;
        }
    }	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        RotationPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (FireTime <= 0f)
        {
            Fire();
            FireTime = 1f / FireRate;
        }

        FireTime -= Time.deltaTime;
	}

    void Fire()
    {
        GameObject bulletFire = (GameObject)Instantiate(Bullet, PointOfFire.position, PointOfFire.rotation);
        FireBullet bullet = bulletFire.GetComponent<FireBullet>();
        if (bullet != null)
            bullet.Find(target);
    }

    private void OnDrawGizmosSelected() //Unity function used to able to view the range of a turret
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
