using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBehavior
{
    // Called when a behavior starts
    public abstract void Start(Rat rat);

    // Update is called once per frame while behavior is active
    public abstract void Update(Rat rat);

    // Called when behavior is ended
    public abstract void Stop(Rat rat);
}
