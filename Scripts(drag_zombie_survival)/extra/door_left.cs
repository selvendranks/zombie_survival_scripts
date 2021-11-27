using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_left : MonoBehaviour
{
    yellow_key yell;
    AudioSource adi;
    [SerializeField] AudioClip opening;
    [SerializeField] Canvas orang_key_text;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
        yell = FindObjectOfType<yellow_key>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (yell.yellow() == true)
                {
                    GetComponent<Animator>().SetTrigger("open");
                    adi.PlayOneShot(opening);
                    print("opening");

                }
                else
                {
                    orang_key_text.enabled = true;
                    Invoke("text_off", 3f);
                }
                break;
        }
    }
  void text_off()
    {
        orang_key_text.enabled = false;
    }
}
