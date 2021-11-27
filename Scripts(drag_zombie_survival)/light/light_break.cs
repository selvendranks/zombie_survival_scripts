using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_break : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip breakage;
    bool isbrreaked = false;
    public void Start()
    {
        adi = GetComponent<AudioSource>();
    }

   public void breaaked()
    {
        GameObject spot = transform.GetChild(21).gameObject;
        GameObject bulb = transform.GetChild(18).gameObject;
      if(!adi.isPlaying&&isbrreaked == false)
        adi.PlayOneShot(breakage);
        isbrreaked = true;
        bulb.SetActive(false);
        spot.SetActive(false);
    }
}
