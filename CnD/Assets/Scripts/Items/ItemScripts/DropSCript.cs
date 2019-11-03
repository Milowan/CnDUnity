using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSCript : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
