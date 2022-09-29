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

    [SerializeField] private string mainMenu_Sound; 
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
        SoundManager.Instance.setEffect(mainMenu_Sound);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.IsInGame)
        {
            MenuPopUpUI.gameObject.SetActive(true);
            GameManager.Instance.Pause();
            GameManager.Instance.IsCursorOn(true);
        }
    }

    public void Initialize()
    {
        MainUI.Initialize();
        GameStartPopUpUI.Initialize();
        InGameUI.Initialize();
        MenuPopUpUI.Initialize();
        GameOverUI.Initialize();
        CreditUI.Initialize();
        ClearUI.Initialize();
    }

}
