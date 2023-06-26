using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioClip[] mouseSounds;

    [SerializeField] float timer = 10f;
    float currentTime;

    public bool animalSpawned = false;

    AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();

        currentTime = timer;
    }


    private void Update() {
        currentTime -= Time.deltaTime;

        if(timer <= 0)
        {
            if(animalSpawned)
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }   
            
            currentTime = timer;
        }
    }


    public void PlayHoverSoundEffect()
    {
        audioSource.PlayOneShot(mouseSounds[Random.Range(0,2)], 0.2f);
    }
    public void PlayerClickSoundEffect()
    {
        audioSource.PlayOneShot(mouseSounds[2], 0.25f);
    }
}
