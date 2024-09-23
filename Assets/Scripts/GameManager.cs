using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] int timeToEnd;

    bool endGame = false;
    bool win = false;
    bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time: " +  timeToEnd + " s");

        if(timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame) {
            EndGame();
        }
    }

    void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        if (win)
        {
            Debug.Log("You win! Reload?");
        }
        else
        {
            Debug.Log("You lose! Reload?");
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1;
        gamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
