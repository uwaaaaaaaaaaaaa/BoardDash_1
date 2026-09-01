using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title : MonoBehaviour
{
    public static int jumpTrue;
    public int settingMenu = 0;
    public GameObject SettingPanel;
    public Button SetBtn;
    public Button JpnBtn;
    public Sprite gear;
    public Sprite back;
    public Sprite jon;
    public Sprite joff;
    //音量調整用のスライダー
    public Slider volumeSlider;
    //音量調整用の変数
    public float volume;
    //音量調整のためのAudioSource
    private AudioSource audioSource;

    public void Start()
    {
        jumpTrue = PlayerPrefs.GetInt("Jump", 0);
        SettingPanel.SetActive(false);
        volume = PlayerPrefs.GetFloat("Volume", 1.0f);
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = volume;
        audioSource.volume = volume;
        volumeSlider.onValueChanged.AddListener(PlaySound);
    }
    public void PlaySound(float value)
    {
        volume = volumeSlider.value;
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        //AudioSourceに入ってる音を再生する
        audioSource.Play();
    }
    public void MoveScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void JumpON()
    {
        if(jumpTrue == 0)
        {
            jumpTrue = 1;
        }
        else {
            jumpTrue = 0; 
        }
        PlayerPrefs.SetInt("Jump", jumpTrue);
        UodateBtn();
        
    }
    public void settingON()
    {
        if(settingMenu == 0)
        {
            settingMenu = 1;
            SettingPanel.SetActive(true);
        }
        else
        {
            settingMenu = 0;
            SettingPanel.SetActive(false);
        }
        UodateBtn();
    }
    void UodateBtn()
    {
        Image imageS = SetBtn.GetComponent<Image>();
        Image imageJ = JpnBtn.GetComponent<Image>();
        imageS.sprite = (settingMenu == 1) ? back : gear;
        imageJ.sprite = (jumpTrue == 1) ? jon : joff;
    }
}
