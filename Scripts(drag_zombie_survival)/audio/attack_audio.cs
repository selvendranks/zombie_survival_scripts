using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_audio : MonoBehaviour
{
    AudioSource ad;
    [SerializeField] AudioClip attacking;

    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        
    }

    public void attacki()
    {
        if(!ad.isPlaying)
        {
            ad.PlayOneShot(attacking);
        }
    }

    public void stopp()
    {
        ad.Stop();
    }
}
