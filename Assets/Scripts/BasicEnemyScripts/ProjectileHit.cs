using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public GameObject fullBullet;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(fullBullet);
    }
}
