using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseSys : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseBtn;
    public Text scoreP;
    public Text HiscoreP;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
    }
    void Update()
    {
        if (UISys.GameOver)
        {
            pauseBtn.SetActive(false);
        }
        else
        {
            pauseBtn.SetActive(true);
        }
    }
    
    public void PauseGame()
    {
        pauseBtn.SetActive(false);
        scoreP.text = UISys.score.ToString();
        HiscoreP.text = UISys.Hiscore.ToString();
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ResetGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;
        UISys.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("title");
    }
}
