using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20f;
        attackCD = 4f;
        CDTimer = 0f;
        health = maxHealth;
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        tDelayed = movDelay;
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
        stats = new Stats();
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Die()
    {

        status = CharacterStatus.DEAD;
    }

    protected override void SetStats()
    {
        stats.attack = 15f;
        stats.defense = 1.75f;
        stats.evasion = 2f;
    }
}
