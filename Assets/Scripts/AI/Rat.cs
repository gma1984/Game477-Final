using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rat : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float checkRadius = 3f;
    public float wanderRange = 4f;
    public LayerMask moveMask;
    public Rigidbody2D rb;
    public Transform player;

    private bool nearPlayer = false;
    private float panicTime;

    private AIBehavior idle = new IdleBehavior();
    private AIBehavior flee = new FleeBehavior();
    private AIBehavior panic = new FleeBehavior();
    private AIBehavior activeBehavior;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Player_Controller>().transform;

        activeBehavior = idle;
        activeBehavior.Start(this);
    }

    public void MoveTo(float xPos)
    {
        var forceDir = new Vector2(xPos, transform.position.y);
        forceDir = (forceDir - (Vector2)transform.position).normalized;
        rb.AddForce(forceDir * moveSpeed, ForceMode2D.Force);

        if (forceDir.x > 0) transform.localScale.Set(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else transform.localScale.Set(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //rb.MovePosition((Vector2)transform.position + (forceDir * moveSpeed * Time.fixedDeltaTime));
        //rb.velocity = forceDir * moveSpeed + Physics2D.gravity;
    }

    public Vector2 GetFleeRange()
    {
        var rHit = Physics2D.Raycast(transform.position, transform.right, checkRadius * 2f, moveMask);
        var lHit = Physics2D.Raycast(transform.position, -transform.right, checkRadius * 2f, moveMask);
        var rX = rHit.point.x != 0 ? rHit.point.x : transform.position.x + checkRadius * 2f;
        var lX = lHit.point.x != 0 ? lHit.point.x : transform.position.x - checkRadius * 2f;

        return new Vector2(lX, rX);
    }

    public Vector2 GetWanderRange()
    {
        var rHit = Physics2D.Raycast(transform.position, transform.right, wanderRange, moveMask);
        var lHit = Physics2D.Raycast(transform.position, -transform.right, wanderRange, moveMask);
        var rX = rHit.point.x != 0 ? rHit.point.x : transform.position.x + wanderRange;
        var lX = lHit.point.x != 0 ? lHit.point.x : transform.position.x - wanderRange;

        return new Vector2(lX, rX);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        activeBehavior.Update(this);
    }

    void FixedUpdate()
    {
        activeBehavior.FixedUpdate(this);
    }

    void ChangeAIBehavior(AIBehavior behavior)
    {
        if (activeBehavior == behavior) return;

        activeBehavior.Stop(this);
        activeBehavior = behavior;
        behavior.Start(this);
    }

    void CheckForPlayer()
    {
        if (Vector3.Distance(player.position, transform.position) <= checkRadius)
        {
            nearPlayer = true;
            panicTime = Time.time + 1.5f;
            ChangeAIBehavior(flee);
        }
        else if (Time.time > panicTime)
        {
            nearPlayer = false;
            ChangeAIBehavior(idle);
        }
    }
}
