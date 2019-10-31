using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float maxForce;
    public float wanderRangeMax;
    public float wanderRangeMin;
    protected Vector3 targetPos;
    private Vector3 current;
    private Vector3 currentV;
    private Vector3 correction;
    public float movDelay;
    protected float tDelayed;
    protected float attackCD;
    protected float CDTimer;

    protected Transform pos;
    protected Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        tDelayed = movDelay;
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentV = body.velocity;
        if (tDelayed >= movDelay)
        {
            if (status == CharacterStatus.IDLE)
            {
                Wander();
            }
            else if (status == CharacterStatus.CHASING)
            {
                Chase();
            }
            else if (status == CharacterStatus.FIGHTING)
            {
                Attack();
            }
        }
        else
        {
            tDelayed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider response)
    {
        if (response.gameObject.tag == "Player")
        {
            status = CharacterStatus.CHASING;
            target = response.gameObject.GetComponent<Character>();
        }
    }

    private void OnTriggerExit(Collider response)
    {
        if (response.gameObject.tag == "Player")
        {
            status = CharacterStatus.IDLE;
            target = null;
        }
    }

    protected override void Attack()
    {
        if (target != null)
        {
            if (CDTimer >= attackCD)
            {
                if (Random.Range(0, 100) > target.GetEvasion())
                {
                    target.TakeDamage(GetAttack());
                }
                CDTimer = 0;
            }
            else
            {
                CDTimer += Time.deltaTime;
            }

        }
    }

    private void Steer()
    {
        correction = targetPos - current;
        correction = correction.normalized * movSpeed;
        correction -= currentV;
        correction = Vector3.ClampMagnitude(correction, maxForce);
        currentV = Vector3.ClampMagnitude(currentV + correction, movSpeed);
        pos.position += currentV;

        if ((targetPos - current).magnitude < 0.025f)
        {
            if (status == CharacterStatus.IDLE)
            {
                targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax) + pos.position.x, Random.Range(wanderRangeMin, wanderRangeMax) + pos.position.y, 0f);
            }
            else if (status == CharacterStatus.CHASING)
            {
                status = CharacterStatus.FIGHTING;
            }
            tDelayed = 0f;
        }
    }

    private void Wander()
    {
        current = body.position;
        Steer();
    }

    private void Chase()
    {
        targetPos = target.GetComponent<Transform>().position;
        current = body.position;
        Steer();
    }


}
