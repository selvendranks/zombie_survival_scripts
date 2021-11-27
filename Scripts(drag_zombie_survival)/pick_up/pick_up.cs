using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pick_up : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] ammotypes ammo;
    [SerializeField] AudioClip pick_audio;
    pick_up_text pick_text;
    Ammo am;
    wepon_single weponsin;
    wepon weepon;
    private void Start()
    {
        pick_text = FindObjectOfType<pick_up_text>();
        weepon = FindObjectOfType<wepon>();
        weponsin = FindObjectOfType<wepon_single>();
        adi = GetComponent<AudioSource>();
        am = FindObjectOfType<Ammo>();

    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                am.addammo(ammo);
                adi.PlayOneShot(pick_audio);
                pick_text.show(ammo.ToString());
                Destroy(gameObject,0.5f);
                weponsin.magzine();
                weepon.magzine();
                break;
        }
    }
}
