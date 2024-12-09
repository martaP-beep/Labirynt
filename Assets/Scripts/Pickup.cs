using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip clip;
    public virtual void Picked()
    {
        GameManager.gameManager.PlayClip(clip);
        Destroy(this.gameObject);
        Debug.Log("Z³apany");
    }
}
