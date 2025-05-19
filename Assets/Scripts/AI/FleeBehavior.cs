using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : AIBehavior
{
    float fleeX;

    // Called when a behavior starts
    public override void Start(Rat rat)
    {
        fleeX = rat.transform.position.x;
    }

    // Update is called once per frame while behavior is active
    public override void Update(Rat rat)
    {
        var wanderRange = rat.GetFleeRange();
        var playerX = rat.player.transform.position.x;
        fleeX = Mathf.Abs(wanderRange.x - playerX) >= Mathf.Abs(wanderRange.y - playerX) ? wanderRange.x : wanderRange.y;
    }

    // Called when behavior is ended
    public override void Stop(Rat rat)
    {

    }

    public override void FixedUpdate(Rat rat)
    {
        rat.MoveTo(fleeX);
    }
}
