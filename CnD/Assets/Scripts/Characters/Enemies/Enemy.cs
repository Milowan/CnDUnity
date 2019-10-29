using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float maxForce;
    public float wanderRangeMax;
    public float wanderRangeMin;
    private Vector3 targetPos;
    private Vector3 current;
    private Vector3 currentV;
    private Vector3 correction;
    public float movDelay;
    private float tDelayed;

    private Transform pos;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        tDelayed = movDelay;
    }

    // Update is called once per frame
    void Update()
    {
        currentV = body.velocity;
        if (tDelayed >= movDelay)
        {
            if (status == CharacterStatus.IDLE)
            {
                Wander();
            }
            else if (status == CharacterStatus.CHASING)
            {
                Chase();
            }
        }
        else
        {
            tDelayed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider response)
    {
        if (response.gameObject.tag == "Player")
        {
            status = CharacterStatus.CHASING;
            target = response.gameObject.GetComponent<Character>();
        }
    }

    private void OnTriggerExit(Collider response)
    {
        if (response.gameObject.tag == "Player")
        {
            status = CharacterStatus.IDLE;
            target = null;
        }
    }

    private void Steer()
    {
        correction = targetPos - current;
        correction = correction.normalized * movSpeed;
        correction -= currentV;
        correction = Vector3.ClampMagnitude(correction, maxForce);
        currentV = Vector3.ClampMagnitude(currentV + correction, movSpeed);
        pos.position += currentV;

        if (pos.position == targetPos)
        {
            tDelayed = 0f;
        }
    }

    private void Wander()
    {
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
        current = body.position;
        Steer();
    }

    private void Chase()
    {
        targetPos = target.GetComponent<Transform>().position;
        current = body.position;
        Steer();
    }


}
