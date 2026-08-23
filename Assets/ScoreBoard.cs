using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text HiScoreTx;
    private int HiScore;
    // Start is called before the first frame update
    void Start()
    {
        HiScore = PlayerPrefs.GetInt("HighScore", 0);
        HiScoreTx.text = HiScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ResetHi()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
        HiScore = PlayerPrefs.GetInt("HighScore", 0);
        HiScoreTx.text = HiScore.ToString();
    }
}
