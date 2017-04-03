using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {


    private Transform target;
    public int PointsPerKill = 25;
    public float speed = 50f;
    public GameObject BulletEffect;
    public void Find (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update ()
    {
	    if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;//gets direcgtion vecto in order to transform and translate bullet into desired map location
        float FrameDistance = speed * Time.deltaTime; //is the  time elapsed between two frame rate updates - makes it consistent with the bullet speed

        if (direction.magnitude <= FrameDistance)
        {
            Hitt();
            return;
        }
        transform.Translate(direction.normalized * FrameDistance, Space.World); // normalizes frame rate so each bullet moves equally
	}

    void Hitt()
    {
        GameObject effect = (Instantiate(BulletEffect, transform.position, transform.rotation));
        Destroy(effect, 1f);
        Destroy(target.gameObject);
        Destroy(gameObject);
        Stats.TechTrash = Stats.TechTrash + PointsPerKill;
    }
}
