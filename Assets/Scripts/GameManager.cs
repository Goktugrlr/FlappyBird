using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject loadingScreen;
    public GameObject scoreUI;
    public Text lastScore;
    public Text score;
    public PipeSpawner pipeSpawner;
    public AudioSource hit;
    public BirdMovement bird;

    
    public void StartGame()
    {
        loadingScreen.SetActive(true);
        pipeSpawner.enabled = false;
        scoreUI.SetActive(false);
    }

    public void GameStarted()
    {
        loadingScreen.SetActive(false);
        pipeSpawner.enabled = true;
        scoreUI.SetActive(true);
    }

    public void updateScore()
    {
        score.text = bird.scoreCounter.ToString();
    }

    public void Death()
    {
        Time.timeScale = 0;
        lastScore.text = "YOUR SCORE:" + bird.scoreCounter.ToString();
        scoreUI.SetActive(false);
        deathScreen.SetActive(true);
        hit.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
