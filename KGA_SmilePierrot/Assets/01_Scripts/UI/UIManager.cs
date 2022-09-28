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
    public CreditUI CreditUI;
    public ClearUI ClearUI;

    [SerializeField] private string mainScene_sound;
    private void Awake()
    {
        MainUI = GetComponentInChildren<MainUI>();
        GameStartPopUpUI = GetComponentInChildren<GameStartPopUpUI>();
        InGameUI = GetComponentInChildren<InGameUI>();
        MenuPopUpUI = GetComponentInChildren<MenuPopUpUI>();
        GameOverUI = GetComponentInChildren<GameOverUI>();
        CreditUI = GetComponentInChildren<CreditUI>();
        ClearUI = GetComponentInChildren<ClearUI>();
   
        Initialize();
    }
    private void Start()
    {
       SoundManager.Instance.setEffect(mainScene_sound);        
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
