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
    private bool gameOver = false;

    private int rescuedScore = 0;
    private int inHelicopterCount = 0;

    private void Awake()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Then restart the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameOver()
    {
        gameOver = true;

        if (rescuedScore == 8)
        {
            victoryScreen.SetActive(true);
        } 
        else
        {
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

    public void setRescuedScore(int numRescued)
    {
        rescuedScore += numRescued;
    }

    public void addHeliCount()
    {
        inHelicopterCount++;
        inHelicopterText.SetText("Soldiers in Helicopter: " + inHelicopterCount);
        Debug.Log("changing Ui");
    }
}
