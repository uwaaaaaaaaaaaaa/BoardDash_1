using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISys : MonoBehaviour
{
    public Text scoretx;
    public float addInterval = 0.5f;
    public static int score;
    private float timer = 0f;
    public static bool GameOver;
    public GameObject Player;
    public GameObject gvPanel;
    public Text scoretxG;
    public Text HiScoretx;
    public static int Hiscore;
    
    //AudioŠÖŒW
    public AudioSource audioSource;
    public AudioClip pushClip;
    public AudioClip stopClip;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        GameOver = false;
        Player.SetActive(true);
        gvPanel.SetActive(false);
        Hiscore = PlayerPrefs.GetInt("HighScore", 0);
        HiScoretx.text = Hiscore.ToString();
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("Volume", 1.0f);
        audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= addInterval)
        {
            timer = 0f;
            if (!GameOver)
            {
                score++;
            }
                scoretx.text = score.ToString();
        }
        if (GameOver) { 
            Player.SetActive(false);
            gvPanel.SetActive(true);
            scoretxG.text = score.ToString();
            CheckHighScore();
        }
        audioSource.volume = volume;
    }
 
    
    public void Retry()
    {
        GameOver = false;
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void Quit()
    {
        SceneManager.LoadScene("title");
    }
    private void CheckHighScore()
    {
        if(score > Hiscore)
        {
            Hiscore = score;
            PlayerPrefs.SetInt("HighScore", Hiscore);
            PlayerPrefs.Save();
        }
        HiScoretx.text = Hiscore.ToString();
    }

    public void StopSound() {
        audioSource.clip = stopClip;
        audioSource.Play();
    }
    public void PushSound()
    {
        audioSource.clip = pushClip;
        audioSource.Play();
    }
}
