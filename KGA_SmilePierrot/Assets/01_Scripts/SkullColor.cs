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

    private void Start()
    {
        anim = GetComponent<Animator>();  
    }
    private void Update()
    {
        SkullColorCheck(); 
    }
    private void SkullColorCheck()
    {
        Debug.DrawRay(transform.position, transform.right.normalized * 5f, Color.red);
       
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("MagicSitck");
            Debug.Log("아아"); 
            layerMask = LayerMask.GetMask("Skull");

            if (Physics.Raycast(transform.position, transform.right, out hitInfo, 60f, layerMask) == false)
            {
                return;
            }

            Debug.Log(hitInfo.transform.gameObject.name);
        }
    }
}
