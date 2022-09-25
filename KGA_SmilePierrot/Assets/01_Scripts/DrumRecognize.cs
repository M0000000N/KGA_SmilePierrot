using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    enum EColor
    {
        RED,
        BLUE,
        GREEN,
        WHITE,
    }
//�� : 1 , �� : 2, �� : 3, �� :4, �� : 5
public class DrumRecognize : MonoBehaviour
{
    private RaycastHit hitInfo;
    private int layerMask;

    public Pannel pannel;

    private int clickCount;

    [SerializeField]
    private GameObject[] Drum;

    // �ִϸ��̼Ǻκ�
    [SerializeField]
    private Animator anim;

    private bool isStickMove;
    private bool isStickState;


    void Start()
    {
        isStickMove = true;
    }

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

            Debug.Log($"Panel Name : {pannel.RandomMaterial[clickCount].name}");
            Debug.Log($"hitInfo : {hitInfo.transform.GetComponent<MeshRenderer>().sharedMaterial.name}");
            if (pannel.RandomMaterial[clickCount].name == hitInfo.transform.GetComponent<MeshRenderer>().sharedMaterial.name)
            {
                Debug.Log("����");
                //Debug.Log($"{hitInfo.transform.gameObject.name} : ������Ʈ");
            }
            else
            {
                Debug.Log("����ġ");
                // Ʋ���� �� ���� ���� 
                // HP 0 -> ���ӿ��� 

                GameManager.Instance.Damaged();
                clickCount = 0;
                pannel.Initialize();
                return;
            }
            clickCount++;

            if (pannel.RandomMaterial.Length <= clickCount)
            {
                GameManager.Instance.NextStage();
                clickCount = 0;
                pannel.Initialize();
            }

        }

    }

}