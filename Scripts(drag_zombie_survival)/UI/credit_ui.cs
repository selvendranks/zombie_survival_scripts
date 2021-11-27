using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credit_ui : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] Canvas menu;
    [SerializeField] AudioClip click;
     Canvas credits;
    Animation cred_anim;

    private void Start()
    {
        cred_anim = GetComponent<Animation>();
        adi = GetComponent<AudioSource>();
        credits = GetComponent<Canvas>();
    }
    public void credit()
    {
        credits.enabled = true;
        cred_anim.Play();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& menu!=null & credits!=null)
        {
            adi.PlayOneShot(click);
            cred_anim.Stop();
            menu.enabled = true;
            credits.enabled = false;
            
        }
    }
}
