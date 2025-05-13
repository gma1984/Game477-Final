using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public GameObject fullBullet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletExpire", 3f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(fullBullet);
    }
}
