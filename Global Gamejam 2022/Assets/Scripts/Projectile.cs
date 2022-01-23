using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float mySpeed = 70f;
    public float myRange = 10f;
    private float myDist;
    private Transform target;

    //Seeks out a target
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * mySpeed;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    //What happens when you hit a target
    void HitTarget()
    {
        float randomFloat = Random.Range(0f, 100f);
        if(randomFloat <= 20f)
        {
            target.GetComponent<Health>().Damage(0);
        }
        else if(20f<randomFloat&&randomFloat<=95f)
        {
            target.GetComponent<Health>().Damage(5);
        }
        else
        {
            target.GetComponent<Health>().Damage(10);
        }
        Destroy(gameObject);
    }
}
