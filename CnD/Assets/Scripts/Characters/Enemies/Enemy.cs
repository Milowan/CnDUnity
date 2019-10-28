using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Vector3 target;
    private Vector3 current;
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
        current = body.velocity;
    }

    private void Steer()
    {
        correction = current - target;
    }

    private void Wander()
    {

    }

    private void Chase()
    {

    }
}
