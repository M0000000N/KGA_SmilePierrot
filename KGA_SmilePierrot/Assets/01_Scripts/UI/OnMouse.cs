using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnMouse : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image arrow;

    private void Start()
    {
        text = GetComponentInParent<TextMeshProUGUI>();
        arrow = GetComponentInChildren<Image>();
        arrow.gameObject.SetActive(false);
    }
    private void OnMouseEnter()
    {
        text.color = new Color(255, 255, 0, 255);
        text.fontStyle = FontStyles.Underline;
        arrow.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        text.color = new Color(255, 255, 255, 255);
        text.fontStyle = FontStyles.Normal;
        arrow.gameObject.SetActive(false);
    }
}
