using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dais : Interactable
{
    public Sprite spOn;
    public bool hasGem;


    private void OnTriggerEnter(Collider response)
    {

        if (response.CompareTag("Gem") && hasGem == false)
        {
            GetComponent<SpriteRenderer>().sprite = spOn;
            hasGem = true;
            Destroy(response.gameObject);
        }
               
    }

}
