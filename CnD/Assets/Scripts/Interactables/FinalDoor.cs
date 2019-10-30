using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Sprite spOpen;
    public Dais daisOne;
    public Dais daisTwo;
    public Dais daisThree;
    public Dais daisFour;
    public Doors finalDoor;
    public void fixedupdate()
    {
        if(daisOne.getIsOn() && daisTwo.getIsOn() && daisThree.getIsOn() && daisFour.getIsOn())
        {
            finalDoor.m_doorCollider.enabled = false;
            finalDoor.GetComponent<SpriteRenderer>().sprite = spOpen;
        }
    }

}
