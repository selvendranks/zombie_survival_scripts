using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blue_key : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip pick;
    [SerializeField] GameObject blu_pick_canva;
    bool blue_pick = false;

    private void Start()
    {
        adi = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                blue_pick = true;
                adi.PlayOneShot(pick);
                blu_pick_canva.SetActive(true);
                Destroy(gameObject, 1f);
                Invoke("hide", 0.9f);
                break;
        }
    }
    public bool blue()
    {
        return blue_pick;
    }
    void hide()
    {
        blu_pick_canva.SetActive(false);
    }
}
