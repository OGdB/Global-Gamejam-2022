using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float mySpeed = 70f;
    public float myRange = 10f;
    private float myDist;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
   
    }
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
        Destroy(gameObject);

    }
}
