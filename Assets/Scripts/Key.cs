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

    public float amplitude = 0.5f; 
    public float speed = 1.0f;
    private Vector3 startPosition;

    void Start()
    {
        // Zapisz pocz¹tkow¹ pozycjê obiektu
        startPosition = transform.position;
    }

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddKey(color);
    }


    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
