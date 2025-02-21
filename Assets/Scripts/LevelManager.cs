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

    [SerializeField] public GameObject gameOverScreen;
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
        gameOverScreen.SetActive(true);
        gameOver = true;
    }

    public bool GameIsOver()
    {
        return gameOver;
    }
}
