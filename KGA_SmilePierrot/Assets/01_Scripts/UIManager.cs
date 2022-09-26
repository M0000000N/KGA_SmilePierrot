using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{
    public MainUI MainUI;
    public GameStartPopUpUI GameStartPopUpUI;
    public InGameUI InGameUI;
    public GameOverUI GameOverUI;
    public MenuPopUpUI MenuPopUpUI;


    public void Initionalize()
    {
        MainUI.Initionalize();
        GameStartPopUpUI.Initionalize();
        InGameUI.Initionalize();
        GameOverUI.Initionalize();
        MenuPopUpUI.Initionalize();
    }
}
