using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    public int points = 5;       

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddPoints(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
