using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip stampTap; //도장 - 인O
    public AudioClip stampEmpty; //도장 - 인X
    public AudioClip WS_1; //실링왁스 탭
    public AudioClip WS_2; // 실링왁스 편지 탭
    public AudioClip WS_close; // 실링왁스 취소

    public AudioClip reDZ_1; //전용도장 탭
    public AudioClip CH_loop; // 편지 홀드
    public AudioClip reDZ_2; // 전용도장 찍자마자 나는 소리
    public AudioClip reDZ_close; //전용도장 취소

    public AudioClip pen; // 가로 싸인칸
    public AudioClip pen_loop; // 그림 싸인칸
    public AudioClip INZ_1; //인주 뚜껑 위로 슬라이드
    public AudioClip INZ_2; //인주 탭

    public AudioClip reset_sound; //리셋 버튼 탭
    public AudioClip PageS; //종이 위로 슬라이드
    public AudioClip LetterS; //편지 위로 슬라이드
    public AudioClip NOPE; //페이지 넘기기 패널티
    public AudioClip Win; //승리 화면
    public AudioClip Lose; //패배화면
    
    AudioSource SoundSource;

    public static SoundManager soundManager;

    void Awake()
    {
        if(SoundManager.soundManager == null)
        {
            SoundManager.soundManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundSource = GetComponent<AudioSource>();
    }

   
    public void StampTapPlaySound()
    {
        SoundSource.PlayOneShot(stampTap);
    }

    public void StampEmptyPlaySound()
    {
        SoundSource.PlayOneShot(stampEmpty);
    }

    public void WS_1PlaySound()
    {
        SoundSource.PlayOneShot(WS_1);
    }

    public void WS_2PlaySound()
    {
        SoundSource.PlayOneShot(WS_2);
    }

    public void WS_closePlaySound()
    {
        SoundSource.PlayOneShot(WS_close);
    }

    public void reDZ_1PlaySound()
    {
        SoundSource.PlayOneShot(reDZ_1);
    }

    public void CH_loopPlaySound()
    {
        SoundSource.PlayOneShot(CH_loop);
    }

    public void reDZ_2PlaySound()
    {
        SoundSource.PlayOneShot(reDZ_2);
    }

    public void reDZ_closePlaySound()
    {
        SoundSource.PlayOneShot(reDZ_close);
    }

    public void penPlaySound()
    {
        SoundSource.PlayOneShot(pen);
    }

    public void pen_loopPlaySound()
    {
        SoundSource.PlayOneShot(pen_loop);
    }

    public void INZ_1PlaySound()
    {
        SoundSource.PlayOneShot(INZ_1);
    }

    public void INZ_2PlaySound()
    {
        SoundSource.PlayOneShot(INZ_2);
    }

    
    public void resetPlaySound()
    {
        SoundSource.PlayOneShot(reset_sound);
    }

    public void PageSPlaySound()
    {
        SoundSource.PlayOneShot(PageS);
    }

    public void LetterSPlaySound()
    {
        SoundSource.PlayOneShot(LetterS);
    }

    public void NopePlaySound()
    {
        SoundSource.PlayOneShot(NOPE);
    }

    public void WinPlaySound()
    {
        SoundSource.PlayOneShot(Win);
    }

    public void LosePlaySound()
    {
        SoundSource.PlayOneShot(Lose);
    }
}
