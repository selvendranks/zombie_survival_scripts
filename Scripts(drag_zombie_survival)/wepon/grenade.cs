using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] float delay;
    [SerializeField] float explosionforce = 10f;
    [SerializeField] float radius = 20f;
    [SerializeField] ammotypes ammo;
    bool blasted = false;
    [SerializeField] AudioClip explode_audio;
    float dist;
   // destructible dest;
  //  float countdown;
   // bool exploded = false;
    void Start()
    {
      //  countdown = delay;
       // dest = FindObjectOfType<destructible>();
        adi = FindObjectOfType<AudioSource>();
       Invoke("explode", delay);
       // adi.PlayOneShot(explode_audio);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void explode()
    {
        adi.PlayOneShot(explode_audio);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] collidersdestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in collidersdestroy)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

           // destructible dest = GameObject.Find("zombie1").GetComponent<destructible>();
            if (rig != null)
            {

              //  dest.destroy(); 
               

            }
        }


        Collider[] colliderforce = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliderforce)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            print("blast");
            if (rig != null)
            {
                rig.AddExplosionForce(explosionforce, transform.position, radius, 1f, ForceMode.Impulse);
               

            }
        }
        
       
       
        Destroy(gameObject,1f);
    }
}
