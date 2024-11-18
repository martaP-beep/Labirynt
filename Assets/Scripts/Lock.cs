using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    bool canOpen = false;


    public bool CheckKey()
    {
        if(GameManager.gameManager.redKeys > 0 
            && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKeys--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKeys > 0
           && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKeys--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKeys > 0
          && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKeys--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz w³aœciwego klucza");
            return false;
        }
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canOpen = true;
            Debug.Log("Mo¿esz u¿yæ klucza");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log("Nie mo¿esz u¿yæ klucza");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
