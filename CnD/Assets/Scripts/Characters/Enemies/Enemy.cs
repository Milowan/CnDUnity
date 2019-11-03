using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float maxForce;
    public float wanderRangeMax;
    public float wanderRangeMin;
    protected Vector3 targetPos;
    protected Vector3 current;
    protected Vector3 currentV;
    protected Vector3 correction;
    private bool hitWall = false;
    public float movDelay;
    protected float tDelayed;
    protected float attackCD;
    protected float CDTimer;
    protected float maxFight = 2;



    // Update is called once per frame
    void FixedUpdate()
    {
        currentV = body.velocity;
        current = body.position;
        //SetDirection(body.velocity);
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
                Chase();
                Strike();
            }
            else if (status == CharacterStatus.ATTACKING)
            {
                AttackLogic();
            }
            else if (status == CharacterStatus.DEAD)
            {
                GetComponent<SphereCollider>().enabled = false;
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

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            hitWall = true;
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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Collision")
        {
            hitWall = false;
        }
        
    }



    protected virtual void AttackLogic()
    {
        if (Random.Range(0, 100) > target.GetEvasion())
        {
            target.TakeDamage(GetAttack());
        }

        status = CharacterStatus.FIGHTING;
    }

    protected override void Strike()
    {
        if (target != null)
        {
            if (CDTimer >= attackCD)
            {
                status = CharacterStatus.ATTACKING;
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

        SetDirection(currentV);
        if ((targetPos - current).magnitude < maxFight)
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
        else
        {
            if (status == CharacterStatus.FIGHTING)
            {
                status = CharacterStatus.CHASING;
            }
        }
        if (hitWall)
        {
            if (status == CharacterStatus.IDLE)
            {
                targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax) + pos.position.x, Random.Range(wanderRangeMin, wanderRangeMax) + pos.position.y, 0f);
            }
        }
    }

    private void Wander()
    {
        Steer();
    }

    private void Chase()
    {
        targetPos = target.GetComponent<Transform>().position;
        Steer();
    }


}
