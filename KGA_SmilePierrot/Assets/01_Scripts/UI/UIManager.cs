using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{
    public MainUI MainUI;
    public GameStartPopUpUI GameStartPopUpUI;
    public InGameUI InGameUI;
    public MenuPopUpUI MenuPopUpUI;
    public GameOverUI GameOverUI;

    private void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPopUpUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void Initialize()
    {
        MainUI.Initialize();
        GameStartPopUpUI.Initialize();
        InGameUI.Initialize();
        MenuPopUpUI.Initialize();
        GameOverUI.Initialize();
    }

}
