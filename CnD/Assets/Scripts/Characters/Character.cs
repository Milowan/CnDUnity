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

    protected Stats stats;
    public CharacterStatus status;
    protected float maxHealth;
    protected float health;
    protected float movSpeed;

    //private Stats stats;
    protected float combatTimer;
    protected Character target;

    protected virtual void SetStats()
    {

    }

    protected virtual void Strike()
    {

    }

    public void TakeDamage(float dmg)
    {
        health -= dmg / GetDefense();
        if (health <= 0)
        {
            Die();
        }
    }

    public float GetEvasion()
    {
        return stats.evasion;
    }

    public float GetAttack()
    {
        return stats.attack;
    }

    public float GetDefense()
    {
        return stats.defense;
    }

    protected virtual void Die()
    {

    }
}
