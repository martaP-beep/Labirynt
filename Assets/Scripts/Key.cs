using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold
}
public class Key : Pickup
{
    public KeyColor color;
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddKey(color);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
