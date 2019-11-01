using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Stats stats;
    public CharacterStatus status;
    public Direction facing;
    protected float maxHealth;
    protected float health;
    protected float movSpeed;

    protected Transform pos;
    protected Rigidbody body;

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

    public void SetDirection()
    {
        Vector3 direction = body.velocity;
        if (Math.Abs(direction.x) > Math.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                facing = Direction.RIGHT;
            }
            else if (direction.x < 0)
            {
                facing = Direction.LEFT;
            }
        }
        else if (Math.Abs(direction.x) < Math.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                facing = Direction.UP;
            }
            else if (direction.y < 0)
            {
                facing = Direction.DOWN;
            }
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
