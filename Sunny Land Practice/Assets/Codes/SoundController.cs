using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioSource[] soundArray;
    private void Awake()
    {
        instance = this;
    }
    public void SoundsEffect(int wichSound)
    {
        soundArray[wichSound].Play();
    }
    public void FixSoundEffect(int wichSound)
    {
        soundArray[wichSound].Play();
        soundArray[wichSound].pitch = Random.Range(0.8f, 1.3f);
    }
}
