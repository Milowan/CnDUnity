using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public AudioSource batSFX;
    private Vector3 swoopEnd;
    private float swoopEndRange;
    private void Start()
    {
        maxHealth = 10f;
        attackCD = 2f;
        CDTimer = 0f;
        movSpeed = 0.05f;
        swoopEndRange = 1f;
        health = maxHealth;
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        maxFight = GetComponent<SphereCollider>().radius / 2;
        tDelayed = movDelay;
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
        stats = new Stats();
        SetStats();
    }

    protected override void Strike()
    {
        if (target != null)
        {
            if (CDTimer >= attackCD)
            {
                Swoop();
                CDTimer = 0;
            }
            else
            {
                CDTimer += Time.deltaTime;
            }

        }
    }

    private void Swoop()
    {
        swoopEnd = ((targetPos - current) * 2) + current;
        status = CharacterStatus.ATTACKING;
    }

    protected override void AttackLogic()
    {
        if ((targetPos - current).magnitude < swoopEndRange)
        {
            status = CharacterStatus.FIGHTING;
        }
        else
        {
            correction = swoopEnd - current;
            correction = correction.normalized * (movSpeed * 2);
            correction -= currentV;
            correction = Vector3.ClampMagnitude(correction, maxForce);
            currentV = Vector3.ClampMagnitude(currentV + correction, (movSpeed * 2));
            pos.position += currentV;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (status == CharacterStatus.ATTACKING && collision.gameObject.tag == "Player")
        {
            if (Random.Range(0, 100) > target.GetEvasion())
            {
                target.TakeDamage(GetAttack());
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    protected override void Die()
    {
        status = CharacterStatus.DEAD;
    }

    protected override void SetStats()
    {
        stats.attack = 3f;
        stats.defense = 0.5f;
        stats.evasion = 20f;
    }
}
