using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public TextMeshProUGUI rescuedText;
    public TextMeshProUGUI inHelicopterText;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject maxCapacityMsg;
    private bool gameOver = false;

    private int rescuedScore = 0;
    private int inHelicopterCount = 0;

    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
        maxCapacityMsg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Then restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (rescuedScore == 8)
        {
            gameOver = true;
            victoryScreen.SetActive(true);
        }

        if (inHelicopterCount == 3)
        {
            maxCapacityMsg.SetActive(true);
        } 
        else
        {
            maxCapacityMsg.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOver = true;

        if (rescuedScore == 8)
        {
            audioManager.PlaySFX(audioManager.victory);
            victoryScreen.SetActive(true);
        } 
        else
        {
            audioManager.PlaySFX(audioManager.gameOver);
            gameOverScreen.SetActive(true);
        }
    }

    public bool GameIsOver()
    {
        return gameOver;
    }

    public int getRescuedScore()
    {
        return rescuedScore;
    }

    public int getHeliCount()
    {
        return inHelicopterCount;
    }

    public void resetHeliCount()
    {
        inHelicopterCount = 0;
        inHelicopterText.SetText("Soldiers in Helicopter: " + inHelicopterCount);
    }

    public void addRescuedScore(int numRescued)
    {
        rescuedScore += numRescued;
        rescuedText.SetText("Soldiers Rescued: " + rescuedScore);
    }

    public void addHeliCount()
    {
        inHelicopterCount++;
        inHelicopterText.SetText("Soldiers in Helicopter: " + inHelicopterCount);
    }
}
