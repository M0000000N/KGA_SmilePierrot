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
    private void Start()
    {
        effect = GetComponent<AudioSource>();
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.volume = 0.1f; 

        audioClipDic = new Dictionary<string, AudioClip>();

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
        name = "getwand";
        audioClipDic.Add(name, audioEffect[6]);

        name = "GameScene"; 
        audioClipDic.Add(name, audioBGM);

    }
    public void SetBGM(string name)
    {
        BGM.clip = audioClipDic[name];
        BGM.PlayOneShot(audioBGM);
    }

    public void setEffect(string name)
    {
        Debug.Log(name);

       // if (audioClipDic.TryGetValue(name, out AudioClip audioClip))
        
        effect.clip = audioClipDic[name];
        effect.Play();
        
    }

    // 메인메뉴 넘어갈 때 
    public void StopBGM()
    {
        BGM.Stop(); 
    }

    public void StopEffect()
    {
        effect.Stop();
    }

    //// BGM 부분
    //private void PlayBGM()
    //{
    //   if(audioClipDic.TryGetValue("fail.mp3", out AudioClip audioClip))
    //    {
    //        audio.PlayOneShot(audioClip); 
    //    }
    //}

    //// EFFECT 부분 
    //private void PlayEffect(string name)
    //{
    //    if(audioClipDic.TryGetValue(name, out AudioClip audioClip))
    //    {

    //    }

    //}

}

