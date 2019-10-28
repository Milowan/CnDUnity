using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterStatus
    {
        IDLE,
        FIGHTING,
        CHASING,
        MOVING,
        DEAD
    };

    public CharacterStatus status;
    public float maxHealth;
    private float health;
    public float movSpeed;

    //private Stats stats;
    protected float combatTimer;
    protected Character target;

    protected virtual void Attack()
    {

    }

    protected void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }
}
