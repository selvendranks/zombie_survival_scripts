using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class how_to_play : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] Canvas menu;
    [SerializeField] AudioClip click;
    Canvas how;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
        how = GetComponent<Canvas>();
    }
    public void hoto()
    {
      //  adi = FindObjectOfType<AudioSource>();
        //  gameObject.SetActive(true);
        how.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            adi.PlayOneShot(click);
            // gameObject.SetActive(false);
            menu.enabled = true;
            how.enabled = false;
        }
    }
}
