using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� : 1 , �� : 2, �� : 3, �� :4, �� : 5
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
        
        // ���� ������ ���� 
        if (Input.GetMouseButtonDown(0)&& pannel.ShowAll)
        {
            if (hitInfo.transform.tag == "Drum") // ���ǹ� �ٽ� 
            {
                Debug.Log(hitInfo.transform.gameObject.name);

                // ���ҽ����� ���� �������� 
                // ���� 4�� - �ν� 
                // ���ҽ� material ���� ��ġ ����ġ Ȯ�� 
                if (pannel.RandomMaterial[clickCount] == hitInfo.transform.GetComponent<MeshRenderer>().sharedMaterial)
                {
                    Debug.Log("����");
                    //Debug.Log($"{hitInfo.transform.gameObject.name} : ������Ʈ");
                }
                else
                {
                    Debug.Log("����ġ");
                    // Ʋ���� �� ���� ���� 
                    // HP 0 -> ���ӿ��� 

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