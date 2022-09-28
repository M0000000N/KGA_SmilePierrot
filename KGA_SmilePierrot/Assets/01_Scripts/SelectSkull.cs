using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해골 색깔 인식 및 애니매이션 구현 
public class SelectSkull : MonoBehaviour
{
    private RaycastHit hitInfo;

    int layerMask;

    bool takeStick;

    [SerializeField]
    Animator animator;

    [SerializeField] GameObject DefaultMagicStick;
    [SerializeField] GameObject MagicStick;

    [SerializeField] private string swingStick_Sound;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        takeStick = false;
        DefaultMagicStick.SetActive(true);
        MagicStick.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.IsPause == false && GameManager.Instance.IsInGame)
        {
            SkullColorCheck();
        }
    }

    private void SkullColorCheck()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward.normalized * 5f, Color.red);

        if (Input.GetKeyDown(KeyCode.E) && !takeStick)
        {
            takeStick = true;
            animator.SetTrigger("TakeStick");
            DefaultMagicStick.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.CanSelectSkull && takeStick)
        {
            animator.SetTrigger("MagicSitck");
            SoundManager.Instance.setEffect(swingStick_Sound);
            layerMask = LayerMask.GetMask("Skull");

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward.normalized, out hitInfo, 60f, layerMask))
            {
                Color color = hitInfo.transform.GetComponent<Renderer>().material.color;
                GameManager.Instance.CheckColor(color);
            }
        }
    }

    public void SetStick()
    {
        MagicStick.SetActive(true);
    }

    public void GameStart()
    {
        GameManager.Instance.GameStart();
    }
}