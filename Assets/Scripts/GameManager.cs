using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int points = 0;

    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;

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

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper),time,1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
        {
            redKeys++;
        }
        else if (color == KeyColor.Green)
        {
            greenKeys++;
        }
        else if (color == KeyColor.Gold)
        {
            goldKeys++;
        }
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
