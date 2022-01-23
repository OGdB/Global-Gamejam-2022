using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private SideManager thisSide;
    private Transform target;

    [Header("Attributes")]

    public float range = 5f;
    public float firerate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if (gameObject.tag == "Dark")
        {
            enemyTag = "Light";
            thisSide = GameObject.Find("DarkManager").GetComponent<SideManager>();
        }
        else
        {
            enemyTag = "Dark";
            thisSide = GameObject.Find("LightManager").GetComponent<SideManager>();
        }
    }

    void UpdateTarget()
    {
        if (!target) // Look for enemy if not fighting one
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
            Collider closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < hitColliders.Length; i++)
            {
                Collider hitCollider = hitColliders[i];
                if (hitCollider.tag == enemyTag)
                {
                    float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestEnemy = hitCollider;
                        closestDistance = distance;
                    }
                }
            }

            if (closestEnemy != null)
            {
                target = closestEnemy.transform;
            }
        }
    }

    void Update()
    {
        UpdateTarget();

        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation =  Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / firerate;
        }

        fireCountdown -= Time.deltaTime;    
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate( bulletPrefab, firePoint.position, firePoint.rotation);
        Projectile bullet = bulletGO.GetComponent<Projectile>();

        if (bullet != null)
            bullet.Seek(target);
    }
    // Draws the range of the tower
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnDisable()
    {
        thisSide.amountOfTowersLeft--;
    }
}
