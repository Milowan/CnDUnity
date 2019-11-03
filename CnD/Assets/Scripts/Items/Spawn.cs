﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject item;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y -2 , player.position.z);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
