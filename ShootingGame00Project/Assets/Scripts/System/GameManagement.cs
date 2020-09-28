using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    // スコア関連の関数
    public Text scoreText;
    int gameScore = 0;

    // タイマー関連
    public Text timerText;
    public float gameTime = 60f;
    int seconds;

    // GameStart関連
    public GameObject gameStartUI;

    // Pause関連の関数
    public GameObject gamePauseUI;
    public GameObject pauseButton;

    // GameOver関連の関数
    public GameObject gameOverUI;

    // GameClear関連の関数
    public GameObject gameClearUI;
    public GameObject healthBarBackground;

    //public bool gameClearUI2;

    // NextLevel関連
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    // Player関連
    public GameObject Player;
    BoxCollider2D boxCollider2D;

    // Recoveryと
    public GameObject Recovery;
    public GameObject WeaponUp;

    // Enemy関連
    public GameObject Enemy0;
    public GameObject Enemy1;

    // Meteorite
    public GameObject Meteorite1;
    public GameObject Meteorite2;

    // Boss関連
    public GameObject Boss;

    // BGM関連
    private AudioSource audioSource;
    public AudioClip BGM;

    //public SceneFader sceneFader;


    // Start is called before the first frame update 
    void Start()
    {
        Time.timeScale = 0f;

        // UI関連
        scoreText.text = "SCORE: " + gameScore;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BGM;
        audioSource.Play();
        pauseButton.SetActive(false);
        healthBarBackground.SetActive(false);

        // オブジェクト関連
        boxCollider2D = Player.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = true;
        Player.SetActive(true);
        Recovery.SetActive(true);
        WeaponUp.SetActive(true);

        Enemy0.SetActive(true);
        Enemy1.SetActive(true);
        Meteorite1.SetActive(true);
        Meteorite2.SetActive(true);
        Boss.SetActive(true);

        //nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

    }

    // Update is called once per frame
    void Update()
    {
        //TimeManagement();
        //GamePause();
    }

    public void AddScore()
    {
        gameScore += 50;
        scoreText.text = "SCORE: " + gameScore;

    }

    // タイマーの設定
    public void TimeManagement()
    {

        gameTime -= Time.deltaTime;
        seconds = (int)gameTime;
        timerText.text = seconds.ToString();


        if (seconds == 0)
        {
            Debug.Log("TimeOut");
            GameOver();
            Time.timeScale = 1f;
            gameTime = 0f;
            //FindObjectOfType<GameOver>().EndGame();
        }
    }

    public void GameStartUI()
    {

        gameStartUI.SetActive(!gameStartUI.activeSelf);
        //Time.timeScale = 0f;

        if (gameStartUI.activeSelf)
        {
            // gamePauseUIが表示されている間はゲームを停止
            Time.timeScale = 0f;
        }
        else
        {
            // gamePauseUIが表示されてなければ通常通り
            Time.timeScale = 1f;
            pauseButton.SetActive(true);
            healthBarBackground.SetActive(true);
        }
    }

    public void GamePause()
    {

        gamePauseUI.SetActive(!gamePauseUI.activeSelf);
        healthBarBackground.SetActive(false);

        if (gamePauseUI.activeSelf)
        {
            // gamePauseUIが表示されている間はゲームを停止
            Time.timeScale = 0f;
        }
        else
        {
            // gamePauseUIが表示されてなければ通常通り
            Time.timeScale = 1f;
            healthBarBackground.SetActive(true);
        }
    }

    public void GameOver()
    {
        // UI関連
        gameOverUI.SetActive(true);
        pauseButton.SetActive(false);
        healthBarBackground.SetActive(false);

        // Player関連
        Recovery.SetActive(false);
        WeaponUp.SetActive(false);

        // Enemy関連
        Enemy0.SetActive(false);
        Enemy1.SetActive(false);
        Boss.SetActive(false);
        Meteorite1.SetActive(false);
        Meteorite2.SetActive(false);

        audioSource.Stop();

        if (gameOverUI.activeSelf)
        {
            Time.timeScale = 0.2f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void GameClear()
    {
        gameTime += Time.deltaTime;
        seconds = (int)gameTime;
        timerText.text = seconds.ToString();

        gameClearUI.SetActive(true);
        gameOverUI.SetActive(false);
        pauseButton.SetActive(false);
        healthBarBackground.SetActive(false);


        // Player関連
        //Player.SetActive(false);
        boxCollider2D = Player.GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        Recovery.SetActive(false);
        WeaponUp.SetActive(false);

        // Enemy関連
        Enemy0.SetActive(false);
        Enemy1.SetActive(false);
        Boss.SetActive(false);
        Meteorite1.SetActive(false);
        Meteorite2.SetActive(false);

        //FindObjectOfType<Player>().PlayerWin();

        audioSource.Stop();

        if (gameClearUI.activeSelf)
        {
            Time.timeScale = 0.2f;

        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void Retry()
    {
        //SceneManager.LoadScene(scene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Level_Selection");
        Time.timeScale = 1f;
    }

    public void WinLevel()
    {
        Debug.Log("Level Win");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1f;
    }

}
