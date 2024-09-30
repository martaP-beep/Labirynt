using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public bool add; // true - dodaj czas, false -odejmij czas

    public int time = 5;
    public override void Picked()
    {
        base.Picked();
        int sign;
        if (add)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }
        GameManager.gameManager.AddTime(time * sign);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
