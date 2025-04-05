using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gamecontrol : MonoBehaviour
{
    public static gamecontrol instance;
    public Text time;//输入文本变量
    public GameObject gameoverUI;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Update()
    {
        time.text = Time.timeSinceLevelLoad.ToString("00"); //从关卡加载开始计时
    }
    public void PlayAgain()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        player_control.playerdead = false; // 重置玩家死亡状态
    }
    public void Quit()
    {
        Application.Quit();
    }

    

    public static void gameover(bool dead)
    {
        if (dead)
        {
            instance.gameoverUI.SetActive(true);

            Time.timeScale = 0;
        }
    }
}