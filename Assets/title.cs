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
    public void Start()
    {
        jumpTrue = PlayerPrefs.GetInt("Jump", 0);
        SettingPanel.SetActive(false);
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
