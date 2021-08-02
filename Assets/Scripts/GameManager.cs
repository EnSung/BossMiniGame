using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{


    public float audiov;
    public int cnt;
    void Start()
    {
        audiov = 0.1f;
    }

    public enum SceneSet
    {
        MainMenu,
        Ingame,
    }

    public SceneSet CurrentScene = SceneSet.MainMenu;
    void Update()
    {

        if(CurrentScene == SceneSet.Ingame)
        {

            if (Application.platform == RuntimePlatform.Android)
                    
            {

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (UIManager.Instance.isPause)
                    {
                        UIManager.Instance.Continue();
                    }
                    else
                    {
                        UIManager.Instance.Pause();
                    }
                }

            }



        }
        
    }

   
}
