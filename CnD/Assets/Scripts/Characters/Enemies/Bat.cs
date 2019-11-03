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
