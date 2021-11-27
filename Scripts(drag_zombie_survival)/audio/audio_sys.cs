using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_sys : MonoBehaviour
{
    [SerializeField] AudioClip general;
    [SerializeField] AudioClip end;
    AudioSource adi;
    bool stoped = false;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
    }

    private void Update()
    {
        playgeneral(); 
    }

    void playgeneral()
    { 
      if(!adi.isPlaying)
        adi.PlayOneShot(general);
    }
    
   public void death_sound()
    {
        print("doing");
        if(stoped == true)
        { 
        if(!adi.isPlaying)
            adi.PlayOneShot(end);
        }
        else
        {
            adi.Stop();
            stoped = true;
        }
    }
}
