using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빨 : 1 , 파 : 2, 초 : 3, 흰 :4, 주 : 5
public class DrumRecognize : MonoBehaviour
{
    private RaycastHit hitInfo;
    public Pannel pannel;

    private int layerMask;
    private int clickCount;

    [SerializeField]
    private GameObject[] Drum;

    // 애니메이션부분
    [SerializeField]
    private Animator anim;

    void Update()
    {
        ColorDrum();
    }

    private void ColorDrum()
    {
        Debug.DrawRay(transform.position, transform.forward.normalized * 5f, Color.red);

        if (Input.GetMouseButtonDown(0) && pannel.ShowAll)
        {           
            layerMask = 1 << LayerMask.NameToLayer("Drum");

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 60f, layerMask) == false)
            {
                return;
            }
            
            anim.SetTrigger("DrumIsMoving");
            Debug.Log(hitInfo.transform.gameObject.name);


            if (pannel.RandomMaterial[clickCount].name == hitInfo.transform.GetComponent<MeshRenderer>().sharedMaterial.name)
            {
                Debug.Log("맞음");
                
                clickCount++;
                UIManager.Instance.Log.text = "진행 : " + clickCount + "/" + pannel.RandomMaterial.Length + "\n 맞았습니다.";
            }
            else
            {
                Debug.Log("불일치");
                // 틀렸을 때 새로 시작 
                // HP 0 -> 게임오버 
                clickCount = 0;
                UIManager.Instance.Log.text = "진행 : " + clickCount + "/" + pannel.RandomMaterial.Length + "\n 틀렸습니다. HP가 감소하고 다음 스테이지로 넘어갑니다.";

                GameManager.Instance.Damaged();
                pannel.Initialize();
                return;
            }

            if (pannel.RandomMaterial.Length <= clickCount)
            {
                UIManager.Instance.Log.text = "진행 : " + clickCount + "/" + pannel.RandomMaterial.Length + "\n 맞았습니다. 스테이지를 클리어하여 다음 스테이지로 넘어갑니다.";

                GameManager.Instance.NextStage();
                clickCount = 0;
                pannel.Initialize();
            }
        }
    }
}