using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    GameObject Ball, StartGameButton, ScoreText, RestartButton, QuitButton,Flipper1,Flipper2;

    int score;

    [SerializeField]
    Vector3 startPos;

    public int multiplier;
    Rigidbody2D rb1;
    Rigidbody2D rb2;
    bool Canplay;

    public static Gamemanager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;
        score = 0;
        multiplier = 1;
        Canplay = false;
    }
    private void Update()
    {
        if (!Canplay) return;
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Quaternion targetRotation1 = Quaternion.Euler(0, 0, 45);
                rb1.MoveRotation(targetRotation1);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                Quaternion targetRotation1 = Quaternion.Euler(0, 0, 0);
                rb1.MoveRotation(targetRotation1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Quaternion targetRotation2 = Quaternion.Euler(0, 0, -45);
                rb2.MoveRotation(targetRotation2);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Quaternion targetRotation2 = Quaternion.Euler(0, 0, 0);
                rb2.MoveRotation(targetRotation2);
            }

        }
    }
    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score;
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        QuitButton.SetActive(true);
        RestartButton.SetActive(true);


    }

    public void GameStart()
    {
        StartGameButton.SetActive(false);
        ScoreText.SetActive(true);
        RestartButton.SetActive(false);
        Instantiate(Ball, startPos, Quaternion.identity);
        Canplay = true;
        rb1 = Flipper1.GetComponent<Rigidbody2D>();
        rb2 = Flipper2.GetComponent<Rigidbody2D>();

    }
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
}
