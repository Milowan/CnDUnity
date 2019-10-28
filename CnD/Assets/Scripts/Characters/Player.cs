using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float movSpeed;

    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos.Translate(Input.GetAxis("Horizontal") * movSpeed, Input.GetAxis("Vertical") * movSpeed, 0f);
    }
}
