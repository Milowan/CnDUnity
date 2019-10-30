﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 10f;
        attackCD = 1f;
        CDTimer = 0f;
        health = maxHealth;
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
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
        stats.attack = 10f;
        stats.defense = 0.75f;
        stats.evasion = 15f;
    }
}
