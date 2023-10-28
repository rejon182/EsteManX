using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherEnemy : MonoBehaviour
{
    public GameObject bulletPref;
    public float timeBetweenShot = 1.75f;
    float nextShootTime;
    public Transform shotPoint;
	
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShootTime)
        {
            GameObject bulletP = Instantiate(bulletPref,shotPoint.position,Quaternion.identity) as GameObject;
            Bullet bulletScript = bulletP.GetComponent<Bullet>();
	    	
            if (transform.localScale.x < 0f)
            {
                bulletScript.direccion = Vector2.right;
            }
            else
            {
                bulletScript.direccion = Vector2.left;
            }
            nextShootTime = Time.time + timeBetweenShot;
        }
    }
}
