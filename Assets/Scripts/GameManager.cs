using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public TMP_Text timeText;
    public TMP_Text crystalText;
    public TMP_Text redKeysText;
    public TMP_Text greenKeysText;
    public TMP_Text goldKeysText;

    public TMP_Text winText;
    public TMP_Text reloadText;

    public TMP_Text useInfoText;

    public GameObject infoPanel;
    public Image snowflake;


    public int points = 0;

    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;

    [SerializeField] int timeToEnd;

    bool endGame = false;
    bool win = false;
    bool gamePaused = false;

    AudioSource audioSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;
        

    public void SetUseInfo(string info)
    {
        useInfoText.text = info;
    }


    // Start is called before the first frame update
    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        SetUseInfo("");
        snowflake.enabled = false;
        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        winText.text = "Pause";
        reloadText.text = "";

        audioSource = GetComponent<AudioSource>();

        InvokeRepeating(nameof(Stopper), 1, 1);
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        PauseCheck();

        if (endGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
               Application.Quit();
            }
        }
    }

    public void WinGame()
    {
        win = true;
        endGame = true;

    }

    public void AddPoints(int point)
    {
        points += point;
        crystalText.text = points.ToString();
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
        timeText.text = timeToEnd.ToString();
    }

    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        snowflake.enabled = true;
        InvokeRepeating(nameof(Stopper),time,1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Red)
        {
            redKeys++;
            redKeysText.text = redKeys.ToString();
        }
        else if (color == KeyColor.Green)
        {
            greenKeys++;
            greenKeysText.text = greenKeys.ToString();
        }
        else if (color == KeyColor.Gold)
        {
            goldKeys++;
            goldKeysText.text = goldKeys.ToString();
        }
    }

    void Stopper()
    {
        timeToEnd--;
        timeText.text = timeToEnd.ToString();
        snowflake.enabled = false;

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
        infoPanel.SetActive(true);

        if (win)
        {
            PlayClip(winClip);
            // Debug.Log("You win! Reload?");
            winText.text = "You Win!";
            reloadText.text = "Reload? y/n";
        }
        else
        {
            PlayClip(loseClip);
            //Debug.Log("You lose! Reload?");
            winText.text = "You lose!";
            reloadText.text = "Reload? y/n";
        }
    }

    void PauseGame()
    {
        PlayClip(pauseClip);
        infoPanel.SetActive(true);
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        PlayClip(resumeClip);
        infoPanel.SetActive(false);
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
