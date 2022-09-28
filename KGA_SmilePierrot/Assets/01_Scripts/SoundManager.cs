using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonBehaviour<SoundManager>
{
   
   public AudioSource effect;
    public AudioSource BGM; 

    [SerializeField] AudioClip[] audioEffect;
    [SerializeField] AudioClip audioBGM;

   Dictionary<string, AudioClip> audioClipDic;
    private void Awake()
    {
        if (Instance != null)
        {
            DontDestroyOnLoad(Instance.gameObject);
        }
    }

        //foreach (AudioClip audio in audioEffect)
        //{
        
        //}
    private void Start()
    {
        effect = GetComponent<AudioSource>();

        audioClipDic = new Dictionary<string, AudioClip>();

        // audioClipDic.Add(audio.name, audio);
        name = "fail";
        audioClipDic.Add(name, audioEffect[0]);
        name = "Victory";
        audioClipDic.Add(name, audioEffect[1]);
        name = "GameOver";
        audioClipDic.Add(name, audioEffect[2]);
        name = "MainMenu";
        audioClipDic.Add(name, audioEffect[3]);
        name = "menuselect";
        audioClipDic.Add(name, audioEffect[4]);
        name = "wandhit";
        audioClipDic.Add(name, audioEffect[5]);
        //BGM 
        //audioClipDic.Add(name, audioBGM[6]);
        name = "GameScene"; // BGM
        audioClipDic.Add(name, audioBGM);

    }

    public void SetBGM()
    {
        if (audioBGM == null) return;

        BGM = GetComponent<AudioSource>();  
        BGM.clip = audioBGM;
        BGM.PlayOneShot(audioBGM);

    }
    public void setEffect(string name)
    {
        Debug.Log(audioClipDic[name]);
        effect.PlayOneShot(audioClipDic[name]); // �����߳�..
    }

    // ���θ޴� �Ѿ �� 
    public void StopBGM()
    {
        BGM.Stop(); 
    }

    //// BGM �κ�
    //private void PlayBGM()
    //{
    //   if(audioClipDic.TryGetValue("fail.mp3", out AudioClip audioClip))
    //    {
    //        audio.PlayOneShot(audioClip); 
    //    }
    //}

    //// EFFECT �κ� 
    //private void PlayEffect(string name)
    //{
    //    if(audioClipDic.TryGetValue(name, out AudioClip audioClip))
    //    {

    //    }

    //}
  
   }
