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
    }

    // Update is called once per frame while behavior is active
    public override void Update(Rat rat)
    {
        if (nextWander > Time.time)
        {
            var wanderRange = Rat.GetMoveRange();
            wanderX = Random.Range(wanderRange.x, wanderRange.y);
            nextWander = Time.time + Random.Range(minWanderWait, maxWanderWait);
        }

        Rat.MoveTo(wanderX);
    }

    // Called when behavior is ended
    public override void Stop(Rat rat)
    {

    }
}
