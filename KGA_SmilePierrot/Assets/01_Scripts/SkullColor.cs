using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해골 색깔 인식 및 애니매이션 구현 
public class SkullColor : MonoBehaviour
{
    private RaycastHit hitInfo;
    private int layerMask;
    private int clickCount; 

    [SerializeField]
    Animator anim;

    [SerializeField]
    private GameObject[] Skull;

    [SerializeField]
    private string magicStick_Sound; 

    private void Update()
    {
        SkullColorCheck(); 
    }
    private void SkullColorCheck()
    {
        Debug.DrawRay(transform.position, transform.forward.normalized * 5f, Color.red) ;
       
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.CanSelectSkull)
        {
            anim.SetTrigger("MagicSitck");
            SoundManager.Instance.setEffect(magicStick_Sound); 
            layerMask = LayerMask.GetMask("Skull");

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 60f, layerMask))
            {
                Color color = hitInfo.transform.GetComponent<Renderer>().material.color;
                GameManager.Instance.CheckColor(color);
            }
        }
    }
}
