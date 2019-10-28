using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public float maxForce;
    private Vector3 target;
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
        correction = target - current;
        correction = correction.normalized * movSpeed;
        correction -= currentV;
        correction = Vector3.ClampMagnitude(correction, maxForce);
        currentV = Vector3.ClampMagnitude(currentV + correction, movSpeed);
        pos.position += currentV;
    }

    private void Wander()
    {
        //target = Vector3();
    }

    private void Chase()
    {

    }
}
