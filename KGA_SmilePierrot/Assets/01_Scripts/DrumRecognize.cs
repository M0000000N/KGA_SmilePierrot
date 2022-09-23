using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빨 : 1 , 파 : 2, 초 : 3, 흰 :4, 주 : 5
public class DrumRecognize : MonoBehaviour
{
    private RaycastHit hitInfo;
    private LayerMask layerMask;

    public Pannel pannel;

    private int clickCount;

    [SerializeField]
    private GameObject[] Drum;
    void Start()
    {
        //hitInfo = GetComponent<RaycastHit>();

    }
    void Update()
    {
        ColorDrum();

    }
    private void ColorDrum()
    {
        RaycastHit raycast;
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);

        layerMask = LayerMask.GetMask("Drum");
        Physics.Raycast(transform.position, transform.forward, out hitInfo, 60f, layerMask);
        
        // 색이 나오기 전에 
        if (Input.GetMouseButtonDown(0)&& pannel.ShowAll)
        {
            if (hitInfo.transform.tag == "Drum") // 조건문 다시 
            {
                Debug.Log(hitInfo.transform.gameObject.name);

                // 리소스에서 색깔 가져오기 
                // 색깔 4개 - 인식 
                // 리소스 material 색깔 일치 불일치 확인 
                if (pannel.RandomMaterial[clickCount] == hitInfo.transform.GetComponent<MeshRenderer>().sharedMaterial)
                {
                    Debug.Log("맞음");
                    //Debug.Log($"{hitInfo.transform.gameObject.name} : 오브젝트");
                }
                else
                {
                    Debug.Log("불일치");
                    // 틀렸을 때 새로 시작 
                    // HP 0 -> 게임오버 

                    // HP--
                    // stage++
                    // clickcount = 0
                    // return;
                }
                clickCount++;
            }

        }
    }

}