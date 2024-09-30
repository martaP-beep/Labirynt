using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void Picked()
    {
        Destroy(this.gameObject);
        Debug.Log("Z³apany");
    }
}
