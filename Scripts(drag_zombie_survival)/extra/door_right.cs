using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_right : MonoBehaviour
{
    blue_key blu;
    AudioSource adi;
    [SerializeField] AudioClip opening;
    [SerializeField] Canvas blue_key_text;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
        blu = FindObjectOfType<blue_key>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (blu.blue() == true)
                {
                    GetComponent<Animator>().SetTrigger("open");
                    adi.PlayOneShot(opening);
                    print("opening");

                }
                else
                {
                    blue_key_text.enabled = true;
                    Invoke("text_off", 3f);
                }
                break;
        }
    }
    void text_off()
    {
        blue_key_text.enabled = false;
    }
}
