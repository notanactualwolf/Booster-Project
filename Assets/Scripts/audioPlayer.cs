using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> audioList = new List<AudioClip>();
    [Range(0,1)] [SerializeField] float sfxVolume = 1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playSound(int index)
    {
        audioSource.PlayOneShot(audioList[index], sfxVolume);
    }
}
