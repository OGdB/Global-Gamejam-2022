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
    [System.Obsolete]
    void HitTarget()
    {
        //Do damage to enemy
        float randomInt = Random.RandomRange(0, 100);
        if(randomInt <= 20f)
        {
            //damage(0);
        }
        else if(20f < randomInt && randomInt <= 95f)
        {
            //damage(10);
        }
        else
        {
            //damage(20);
        }
        Destroy(gameObject);

    }
}
