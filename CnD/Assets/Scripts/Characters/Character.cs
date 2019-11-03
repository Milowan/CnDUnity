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
    public float health;
    protected float movSpeed;
    protected Transform pos;
    protected Rigidbody body;

    protected Animator m_animator;

    //private Stats stats;
    protected float combatTimer;
    protected Character target;


    protected float animTimer;
    protected float animTimeCounter;

    private void Start()
    {

    }

    protected virtual void SetStats()
    {

    }

    protected virtual void Strike()
    {

    }

    protected virtual void StartAttackAnimation()
    {
        ResetAnimations();
        m_animator.SetBool("Attack", true);
    }

    protected virtual void StartWalkAnimation()
    {
        ResetAnimations();
        m_animator.SetBool("Walking", true);
    }

    protected virtual void StartIdleAnimation()
    {
        ResetAnimations();
        m_animator.SetBool("Idle", true);
    }

    protected virtual void StartDeathAnimation()
    {
        ResetAnimations();
        m_animator.SetBool("Dead", true);
    }

    protected virtual void ResetAnimations()
    {
        m_animator.SetBool("Attack", false);
        m_animator.SetBool("Dead", false);
        m_animator.SetBool("Idle", false);
        m_animator.SetBool("Walking", false);

    }

    protected void InitAtkPool(List<Attack> pool, int poolSize, GameObject prefab)
    {
       for (int i = 0; i < poolSize; ++i)
        {
            pool.Add(Instantiate(prefab, new Vector3(0f, -1000f, 0f), Quaternion.identity).GetComponent<Attack>());
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg / GetDefense();
        if (health <= 0)
        {
            Die();
        }
    }

    public void SetDirection(Vector3 v)
    {
        Vector3 direction = v;
        if (Math.Abs(direction.x) > Math.Abs(direction.y))
        {
            if (status != CharacterStatus.ATTACKING && status != CharacterStatus.FIGHTING)
            {
                StartWalkAnimation();
            }
            if (direction.x > 0)
            {
                facing = Direction.RIGHT;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (direction.x < 0)
            {
                facing = Direction.LEFT;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (Math.Abs(direction.x) < Math.Abs(direction.y))
        {
            if (status != CharacterStatus.ATTACKING && status != CharacterStatus.FIGHTING)
            {
                StartWalkAnimation();
            }
            if (direction.y > 0)
            {
                facing = Direction.UP;
            }
            else if (direction.y < 0)
            {
                facing = Direction.DOWN;
            }
        }
        else 
        {
            if (status != CharacterStatus.ATTACKING && status != CharacterStatus.FIGHTING)
            {
                StartIdleAnimation();
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
