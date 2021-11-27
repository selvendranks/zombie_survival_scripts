using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using TMPro;
public class wepon_single : MonoBehaviour
{ 
    WeponSwitch wswitch;
    Animator animator;
    public recoil rec;
    int num; int num1;
    int inmag, outmag, maxmag;
    AudioSource audio;
    RaycastHit hit;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] public float damage = 3f;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject hiteffect;
    [SerializeField] AudioClip fire;
    [SerializeField] GameObject bullethole;
    [SerializeField] AudioClip Reload;
    light_break breakage;
    EnemyHealth target;
    Ammo Ammoslot;
    bool canshoot = true;
    [SerializeField] float firerate = 1.5f;
    [SerializeField] ammotypes ammo;
    float nextfire = 0f;
    ammotext amu;
    [Header("reload duration")]
    [SerializeField] float reloadtime;
    [SerializeField] float extratime;
    public void Start()
    {
        wswitch = FindObjectOfType<WeponSwitch>();
        animator = GetComponent<Animator>();
        rec = FindObjectOfType<recoil>();
        amu = FindObjectOfType<ammotext>();
        Ammoslot = FindObjectOfType<Ammo>();
        audio = GetComponent<AudioSource>();
        audio.Stop();
        magzine();

        //  ammu.text = "999";
    }
    void Update()
    {
        for (; Ammoslot.GetCurrentAmmo(ammo) > 0; outmag++)
            Ammoslot.ReduceCurrentAmmo(ammo);

        num = Ammoslot.GetCurrentAmmo(ammo);
        reload();
        amu.showammo(inmag, outmag);
        if (Input.GetButtonDown("Fire1") && Time.time > nextfire && !animator.GetCurrentAnimatorStateInfo(0).IsName("reload"))
        {
          
            nextfire = Time.time + firerate;

            if (inmag > 0)
            {
                reducemagz();
                rec.Fire();
                shoot();

            }

        }
        else
        {
            // audio.Stop();
        }


    }

    public void display_ammo()
    {
        // int am = (Ammoslot.GetCurrentAmmo(ammo) / 3);
        // ammu.text = am.ToString();
    }
    void shoot()
    {
       // Ammoslot.ReduceCurrentAmmo(ammo);
        processraycast();
        processraycast2();
        createhitimpact();
        muzzle();

    }

    private void processraycast()
    {

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            Instantiate(bullethole, hit.point + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.LookRotation(hit.normal));
            // Destroy(g, 2f);
            print("hit " + hit.transform.name);
            target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }
    private void processraycast2()
    {

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print("hit " + hit.transform.name);
            breakage = hit.transform.GetComponent<light_break>();
            if (breakage == null) return;
            breakage.breaaked();

        }
        else
        {
            return;
        }
    }
    void muzzle()
    {
        flash.Play();
        // if (!audio.isPlaying)
        audio.PlayOneShot(fire);
        print("don");

    }
    void createhitimpact()
    {
        GameObject impact = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
   public void magzine()
    {
       
        if (ammo.ToString() == "revolver")
        {
            maxmag = 6;
            inmag = maxmag;
        }
        else if (ammo.ToString() == "shotgun")
        {
            maxmag = 5; inmag = maxmag;
        }
        else if (ammo.ToString() == "rifle")
        {
            maxmag = 30; inmag = maxmag;
        }
        else if (ammo.ToString() == "sniper")
        {
            maxmag = 5; inmag = maxmag;
        }
       // outmag = Ammoslot.GetCurrentAmmo(ammo) - maxmag;
    }
    void reducemagz()
    {

        inmag--;
        if (inmag == 0)
        {
            if (outmag > 0)
            {
                Invoke("play_anim", 1f);
                Invoke("exiti", ((float)(reloadtime + (reloadtime * (maxmag - inmag)) + 0.5)));
                //for (; inmag < maxmag && outmag > 0; inmag++, outmag--) ;
            }

        }


    }
   void  play_anim()
    {
        wswitch.enabled = false;
        GetComponent<Animator>().SetBool("reload", true);
        audio.PlayOneShot(Reload);
    }
    void reload()
    {
       // print("reloading");
        if (Input.GetKeyDown(KeyCode.R))
        {
           
            if (outmag > 0&& inmag<maxmag)
            {
                print("reloading");
                print("Working");
                Invoke("play_anim", reloadtime);
                Invoke("exiti", ((float)(reloadtime + (reloadtime* (maxmag-inmag)) + 0.5)));
               // for (; inmag < maxmag && outmag > 0; inmag++,outmag--) ;

 
            }
        }
    }

    void exiti()
    {
        for (; inmag < maxmag && outmag > 0; inmag++, outmag--) ;
        GetComponent<Animator>().SetBool("reload", false);
        wswitch.enabled = true;
        audio.Stop();

    }

}

