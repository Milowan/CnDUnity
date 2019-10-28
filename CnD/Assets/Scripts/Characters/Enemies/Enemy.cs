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

    private Transform pos;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentV = body.velocity;
    }

    private void Steer()
    {
        correction = targetPos - current;
        correction = correction.normalized * movSpeed;
        correction -= currentV;
        correction = Vector3.ClampMagnitude(correction, maxForce);
        currentV = Vector3.ClampMagnitude(currentV + correction, movSpeed);
        pos.position += currentV;
    }

    private void Wander()
    {
        targetPos.Set(Random.Range(wanderRangeMin, wanderRangeMax), Random.Range(wanderRangeMin, wanderRangeMax), 0f);
        current = body.position;
    }

    private void Chase()
    {
        targetPos = target.GetComponent<Transform>().position;
        current = body.position;
    }
}
