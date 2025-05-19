using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : AIBehavior
{
    float nextWander;
    float minWanderWait = 1f;
    float maxWanderWait = 3f;

    float wanderX;

    // Called when a behavior starts
    public override void Start(Rat rat)
    {
        nextWander = Time.time + Random.Range(minWanderWait, maxWanderWait);
        wanderX = rat.transform.position.x;
    }

    // Update is called once per frame while behavior is active
    public override void Update(Rat rat)
    {
        if (Time.time > nextWander)
        {
            var wanderRange = rat.GetWanderRange();
            wanderX = Random.Range(wanderRange.x, wanderRange.y);
            nextWander = Time.time + Random.Range(minWanderWait, maxWanderWait);
            Debug.Log(wanderX);
        }
    }

    // Called when behavior is ended
    public override void Stop(Rat rat)
    {

    }

    public override void FixedUpdate(Rat rat)
    {
        rat.MoveTo(wanderX);
    }
}
