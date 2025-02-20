using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void PlayThisSource(string clipName, float volumeMultiplier)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.volume *= volumeMultiplier;
        source.PlayOneShot((AudioClip)Resources.Load("audio/" + clipName, typeof(AudioClip)));
    }

}
