using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BulletExpire", 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, speed * Time.fixedDeltaTime);
    }

    public Projectile SetDirection(Vector2 dir)
    {
        direction = dir;
        return this;
    }

    public Projectile SetSpeed(float spd)
    {
        speed = spd;
        return this;
    }

    private void BulletExpire()
    {
        Destroy(gameObject);
    }
}
