using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellow_key : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip pick;
    [SerializeField] GameObject yello_canva;
    bool yellow_pick = false;

    private void Start()
    {
        adi = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                yellow_pick = true;
                adi.PlayOneShot(pick);
                yello_canva.SetActive(true);
                Destroy(gameObject, 1f);
                Invoke("hide", 0.9f);
                break;
        }
    }
   public bool yellow()
    {
        return yellow_pick;
    }
    void hide()
    {
        yello_canva.SetActive(false);
    }
}
