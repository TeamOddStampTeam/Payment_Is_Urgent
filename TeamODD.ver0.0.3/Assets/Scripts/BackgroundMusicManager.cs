using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusicManager : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;
    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        }
    }

    private void Update()
    {
        if(HubButton.audiostop == 1)
        {
            backmusic.Stop();
            GameObject.Destroy(BackgroundMusic);
            GameObject.Destroy(backmusic);
        }
    }
}


