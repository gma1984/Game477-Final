using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public float shootDelay = .25f;
    public Vector2 shootDir = Vector2.left;
    public float projectileSpeed = 10f;

    float nextShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShoot)
        {
            nextShoot = Time.time + shootDelay;

            var proj = Instantiate(projectile);
            proj.transform.position = transform.position + (Vector3)shootDir;
            proj.GetComponentInChildren<Projectile>().SetDirection(shootDir).SetSpeed(projectileSpeed);
        }
    }
}
