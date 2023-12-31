using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherEnemyActivate : MonoBehaviour
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
        Debug.Log("Funcion shoot");
        Debug.Log("bulletPref: " + bulletPref );
        Debug.Log("firePoint: " + firePoint );
        if (bulletPref != null && firePoint != null)
        {
            Debug.Log("Shoot! isAttack: "+ isAttack);
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
            Debug.Log("Into Compare Tag");
            StartCoroutine(ShootTime());
        }
    }

    IEnumerator ShootTime()
    {
        isAttack = true;
        yield return new WaitForSeconds(aimingTime);
        anim.SetTrigger("Bones_IsThrowing");
        Shoot();
        yield return new WaitForSeconds(shootingTime);
        isAttack = false;
    }
}