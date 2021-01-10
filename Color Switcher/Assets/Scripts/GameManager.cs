using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;
    public Text countDownText;
    public GameObject player;
    public Text menuScoreText;
    public Text scoreText;

    private void Start()
    {
        menuPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        StartCoroutine(CountDown());
    }

    public void SetScore(int score)
    {
        //PlayerPrefs.SetInt("Score", score);
        menuScoreText.text = "Score : " + score;
        scoreText.gameObject.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ApplicationQuitButton()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }

    IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0f;
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(.9f);
        }
        countDownText.gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().gravityScale = 3.5f;
        player.GetComponent<Player>().enabled = true;
    }
}
