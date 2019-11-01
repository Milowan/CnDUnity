using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Direction facing;

    private bool active;
    protected bool hitOnce;
    protected float movSpeed;
    protected float duration;
    protected float lifeSpan;
    private float dmg;
    private Character target;
    private Transform pos;

    // Start is called before the first frame update
    public void Init(float atk, Direction forward, Transform tf)
    {
        duration = 0f;
        SetAttack(atk);
        facing = forward;
        pos = tf;
        enabled = true;
    }

    private void SetAttack(float atk)
    {
        dmg = atk;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration >= lifeSpan)
        {
            active = false;
        }
        else
        {
            if (facing == Direction.RIGHT)
            {
                pos.Translate(movSpeed, 0f, 0f);
            }
            else if (facing == Direction.LEFT)
            {
                pos.Translate(-movSpeed, 0f, 0f);
            }
            else if (facing == Direction.UP)
            {
                pos.Translate(0f, movSpeed, 0f);
            }
            else
            {
                pos.Translate(0f, -movSpeed, 0f);
            }
        }

        if (!active)
        {
            enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        target = collision.gameObject.GetComponent<Character>();
        if (target != null)
        {
            if (Random.Range(0, 100) > target.GetEvasion())
            {
                target.TakeDamage(dmg);
            }
            if (hitOnce)
            {
                active = false;
            }
        }
        if (collision.gameObject.tag == "Collision")
        {
            active = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        target = null;
    }
}
