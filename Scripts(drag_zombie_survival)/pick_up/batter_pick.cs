using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batter_pick : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip pick_audio;
    pick_up_text pick_text;
    light_system ligh;
    void Start()
    {
        pick_text = FindObjectOfType<pick_up_text>();
        adi = GetComponent<AudioSource>();
        ligh = FindObjectOfType<light_system>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                print("collided");
                adi.PlayOneShot(pick_audio);
                ligh._restore_intensity();
                ligh.restore_angle();
                pick_text.show("battery");
                Destroy(gameObject,0.5f);
                break;
        }
    }
    private void Update()
    {
        print("pick batter");
    }
}
