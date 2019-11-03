using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public AudioSource batSFX;
    private void Start()
    {
        animTimer = 0.2f;
        m_animator = GetComponent<Animator>();
        maxHealth = 10f;
        attackCD = 2f;
        CDTimer = 0f;
        movSpeed = 0.05f;
        health = maxHealth;
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        maxFight = 4f;
        tDelayed = movDelay;
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
        stats = new Stats();
        SetStats();
    }

    private void Update()
    {
        if (status == CharacterStatus.DEAD)
        {
            if (animTimeCounter < animTimer)
            {
                animTimeCounter += Time.deltaTime;
            }
            else if (animTimeCounter >= animTimer)
            {
                animTimeCounter = 0;
                Destroy(this);
            }

        }
        if (status == CharacterStatus.ATTACKING)
        {
            if (animTimeCounter < animTimer)
            {
                animTimeCounter += Time.deltaTime;
            }
            else if (animTimeCounter >= animTimer)
            {
                animTimeCounter = 0;
                StartIdleAnimation();
            }
        }
    }

    protected override void Die()
    {
        status = CharacterStatus.DEAD;
        StartDeathAnimation();
    }

    protected override void SetStats()
    {
        stats.attack = 3f;
        stats.defense = 0.5f;
        stats.evasion = 20f;
    }
}
