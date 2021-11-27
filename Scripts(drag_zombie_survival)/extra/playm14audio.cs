using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playm14audio : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip reload;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
    }

  public void  reload_sound()
    {
       if(!adi.isPlaying)
        adi.PlayOneShot(reload);
    }
}
