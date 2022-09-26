using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpUI : MonoBehaviour
{
    public Transform InitTransform;
    private void Awake()
    {
        transform.position = InitTransform.position;
    }
    private void Start()
    {
        Initionalize();
    }
    public void Initionalize()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
