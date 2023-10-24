using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherEnemyActive : MonoBehaviour
{
    public GameObject bulletPref;
    public float aimingTime = 0.5f;
    public float shootingTime = 1.5f;
	
    public Transform firePoint;
    bool isAttack;
    Animator anim;
	
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    void Shoot()
    {
        if (bulletPref != null && firePoint != null)
        {
            GameObject bulletP = Instantiate(bulletPref, firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletScript = bulletP.GetComponent<Bullet>();
			
            if (transform.localScale.x < 0)
            {
                bulletScript.direccion = Vector2.right;
            }
            else
            {
                bulletScript.direccion = Vector2.left;
            }
        }
    }
	
    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttack == false && other.CompareTag("Player"))
        {
            StartCoroutine(ShootTime());
        }
    }
    IEnumerator ShootTime()
    {
        isAttack = true;
        yield return new WaitForSeconds(aimingTime);
        anim.SetTrigger("isShoot");
        yield return new WaitForSeconds(shootingTime);
        isAttack = false;
    }
}
