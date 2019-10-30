using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{

    private void Start()
    {
        attackCD = 2f;
        CDTimer = 0f;
    }
    protected override void Attack()
    {
        if (CDTimer >= attackCD)
        {

        }
    }

    protected override void Die()
    {

    }
}
