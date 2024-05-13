using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Source --------")]
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Clips --------")]
    public AudioClip pistolShot;
    public AudioClip rifleShot;


    void Start()
    {
   
        
    }

    public void PlaySFX(AudioClip source)
    {
        SFXSource.PlayOneShot(source);
    }
}
