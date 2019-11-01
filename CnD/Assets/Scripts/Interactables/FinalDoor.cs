using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Doors
{
    public bool allGems;
    public Dais daisOne;
    public Dais daisTwo;
    public Dais daisThree;
    public Dais daisFour;
    public void FixedUpdate()
    {
        if(daisOne.hasGem && daisTwo.hasGem && daisThree.hasGem && daisFour.hasGem)
        {
            allGems = true;
            m_doorCollider.enabled = false;
            GetComponent<SpriteRenderer>().sprite = spOpen;
        }
    }

}
