using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.FreezeTime(freezeTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
