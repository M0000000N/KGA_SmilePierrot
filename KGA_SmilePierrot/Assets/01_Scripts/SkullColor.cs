using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ذ� ���� �ν� �� �ִϸ��̼� ���� 
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
        Debug.DrawRay(transform.position, -transform.forward.normalized * 5f, Color.red);
       
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�ƾ�"); 
            layerMask = LayerMask.GetMask("Skull");

            if (Physics.Raycast(transform.position, -transform.forward, out hitInfo, 60f, layerMask) == false)
            {
                return;
            }

            anim.SetTrigger("MagicSitck");
            Debug.Log(hitInfo.transform.gameObject.name);
        }
    }
}
