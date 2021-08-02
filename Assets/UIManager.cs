using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public static UIManager Instance;

        public Image Hpbar;
    public Player player;

    public Boss boss;
    public Slider bossHpbar;


    public GameObject PausePannel;
    public GameObject GameoverPanel;
    public GameObject GameClearPanel;
    public bool isPause;


    public AudioSource audio;
    public Slider audioSlider;

    private void Awake()
    {
        Instance = this;

        audioSlider.value = GameManager.Instance.audiov; 
        audio.volume = audioSlider.value;


        audio.Play();

    }
    void Start()
    {
        audio = GameObject.Find("MusicManager").GetComponent<AudioSource>();
        bossHpbar.maxValue = boss.MaxHp;



    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpUpdate();
        BossHpUpdate();
    }


    void PlayerHpUpdate()
    {

        if(Hpbar == null)
        {
            return;
        }
        Hpbar.fillAmount = player.currentHp / player.MaxHp;      
    }

    void BossHpUpdate()
    {
        if (bossHpbar == null)
        {
            return;
        }

        bossHpbar.value = boss.Hp;
    }

    public void Pause()
    {
        isPause = true;
        Time.timeScale = 0;
        PausePannel.SetActive(true);
    }

    public void Continue()
    {
        isPause = false;
        Time.timeScale = 1;
        PausePannel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void InGame()
    {
        audio.volume = GameManager.Instance.audiov;
        GameManager.Instance.cnt++;
        GameManager.Instance.CurrentScene = GameManager.SceneSet.Ingame;
        SceneManager.LoadScene("Ingame");
        Time.timeScale = 1;
    }

    public void Tomenu()
    {
        GameManager.Instance.cnt++;
        audio.volume = GameManager.Instance.audiov;
        GameManager.Instance.CurrentScene = GameManager.SceneSet.MainMenu;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        GameoverPanel.SetActive(true);
    }


    public void GameClear()
    {
        GameClearPanel.SetActive(true);
    }


    public void SetMusicvolume(float a)
    {
        audio.volume = a;
        GameManager.Instance.audiov = a;
    }

}
