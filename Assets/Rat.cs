using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rat : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float checkRadius = 3f;

    private Transform player;
    private bool nearPlayer = false;

    private static AIBehavior idle = new IdleBehavior();
    private AIBehavior flee = new FleeBehavior();
    private AIBehavior panic = new FleeBehavior();
    private AIBehavior activeBehavior = idle;


    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<Player_Controller>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeAIBehavior(AIBehavior behavior)
    {
        //activeBehavior.End();
        activeBehavior = behavior;
        //behavior.Stop();
    }

    void CheckForPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) <= checkRadius)
        {
            nearPlayer = true;

        }
        else
        {
            nearPlayer = false;
        }
    }
}
