using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using TMPro;
public class wepon : MonoBehaviour
{
    WeponSwitch wswitch;
    playm14audio reload_adi;
    Animator animator;
    public recoil rec;
    int num;
    int num1;
    bool reloaded = false;
    int inmag, outmag, maxmag;
    AudioSource audio;
    RaycastHit hit;
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] public float damage = 3f;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject hiteffect;
    [SerializeField] AudioClip fire;
    [SerializeField] AudioClip Reload;
    EnemyHealth target;
    light_break breakage;
    [SerializeField] GameObject bullethole;
    Ammo Ammoslot;
    [SerializeField] float Firerate = 0.3f;
    [SerializeField] ammotypes ammo;
    ammotext amu;
    bool canshoot = true;
    public void Start()
    {
        wswitch = FindObjectOfType<WeponSwitch>();
        reload_adi = FindObjectOfType<playm14audio>();
        animator = GetComponent<Animator>();
        rec = FindObjectOfType<recoil>();
        canshoot = true;
        amu = FindObjectOfType<ammotext>();
        Ammoslot = FindObjectOfType<Ammo>();
        audio = GetComponent<AudioSource>();
        
        magzine();
       
        //ammu.text = "999";
    }
    void Update()
    {
        for (; Ammoslot.GetCurrentAmmo(ammo) > 0; outmag++)
            Ammoslot.ReduceCurrentAmmo(ammo);
        reload();

        num = Ammoslot.GetCurrentAmmo(ammo);
        
        amu.showammo(inmag,outmag);
        if (Input.GetButton("Fire1")&&inmag>0&&!animator.GetCurrentAnimatorStateInfo(0).IsName("reload"))
        {
            rec.Fire();
            playaudio();
            if (inmag > 0 && canshoot == true)
            {
                shoot();
               
            }
        }
        else
        {
            audio.Stop();
        }
  

    }
    public void display_ammo()
    {
        //ammu.text = Ammoslot.GetCurrentAmmo(ammo).ToString();
    }
  public  void shoot()
    {
        canshoot = false;
        createhitimpact();
        muzzle();
        processraycast();
        processraycast2();
        reducemagz();
        Invoke("firerate", Firerate);

    }
    void firerate()
    {
        canshoot = true;
    }
    private void processraycast()
    {

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Instantiate(bullethole, hit.point + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.LookRotation(hit.normal));
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
      
        
       
    }
    void playaudio()
    {
        if (!audio.isPlaying)
            audio.Play();
    }
    void createhitimpact()
    {
        GameObject impact= Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
    public void magzine()
    {
       
        if (ammo.ToString() == "revolver")
        {
            print("yes");
            maxmag = 6;
            inmag = maxmag;
        }
        else if (ammo.ToString() == "shotgun")
        {
            maxmag = 5;
            inmag = maxmag;
        }
        else if (ammo.ToString() == "rifle")
        {
            maxmag = 30;
            inmag = maxmag;
        }
        else if (ammo.ToString() == "sniper")
        {
            maxmag = 5;
            inmag = maxmag;
        }
        //outmag = Ammoslot.GetCurrentAmmo(ammo) - maxmag;
    }
    void reducemagz()
    {
        
        inmag--;
        if (inmag == 0)
        {
            if (outmag > 0)
            {
                reload_adi.reload_sound();
                GetComponent<Animator>().SetBool("reload", true);
                wswitch.enabled = false;
                Invoke("exiti", 1.2f);
                // inmag += maxmag - inmag;
                // outmag -= maxmag;
            }
        }
       
        
    }
   void reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (outmag > 0 && inmag < maxmag)
            {
                print("Working");
                reload_adi.reload_sound();
                GetComponent<Animator>().SetBool("reload", true);
                wswitch.enabled = false;
                // outmag -= maxmag-inmag;
                // inmag += maxmag - inmag;
                Invoke("exiti", 1.2f);
            }
        }
    }
 
    void exiti()
    {
        for (; inmag < maxmag && outmag > 0; inmag++, outmag--) ;
        GetComponent<Animator>().SetBool("reload", false);
        wswitch.enabled = true;


    }
    
    
}

