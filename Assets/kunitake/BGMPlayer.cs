using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    //audio source hennsuu
    [SerializeField] AudioSource m_Audiosource;
    [SerializeField] AudioClip stage3Bgm;
    [SerializeField] AudioClip resultBgm;
    //stage3 bgm hennsuu
    //result bgm hennsuu

    private void Start()
    {
        
    }

    public void PlayLastStageBGM()
    {
        m_Audiosource.clip = stage3Bgm;
        m_Audiosource.Play();
    }

    public void PlayResultBGM()
    {
        m_Audiosource.clip = resultBgm;
        m_Audiosource.Play();
    }
}
