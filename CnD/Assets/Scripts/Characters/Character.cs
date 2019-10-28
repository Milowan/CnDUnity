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
    private float combatTimer;
    private Character target;
}
