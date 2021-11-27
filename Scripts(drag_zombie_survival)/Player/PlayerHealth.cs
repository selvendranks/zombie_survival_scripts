using UnityEngine.Rendering.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    boss_canvas bos_canas;
    pick_up_text text1;
    AudioSource audi;
    rock_explode rock;
    [SerializeField]  PostProcessVolume volume;
    Vignette vignette;
    [SerializeField] GameObject Menu_ui;
    [SerializeField] float health=100f;
    [SerializeField] GameObject player;
    [SerializeField] Canvas blood;
    [SerializeField] Canvas Ammo_canvas;
    [SerializeField] Canvas aim_canva;
    [SerializeField] GameObject Explosive;
    [SerializeField] GameObject Detonator;
    [SerializeField] AudioClip pick;
    [SerializeField] AudioClip pick_clink;
    DeathHandler dead;
    Healthtext Health;
    audio_sys death_sound;
  //  EnemyAI enemy;
    display_damage disp;

    public void Start()
    {
        bos_canas = FindObjectOfType<boss_canvas>();
        text1 = FindObjectOfType<pick_up_text>();
        audi = GetComponent<AudioSource>();
        rock = FindObjectOfType<rock_explode>();
        volume.profile.TryGetSettings(out vignette);
        disp = FindObjectOfType<display_damage>();
      //  enemy = FindObjectOfType<EnemyAI>();
        death_sound = FindObjectOfType<audio_sys>();
        dead = FindObjectOfType<DeathHandler>();
        Health = FindObjectOfType<Healthtext>(); 
    }
    public void playerhealth(float damage)
    { 
      if(damage>0f)
        disp.showdamage();
        health = health - damage;
        Health.showhealth(health);
        if(health<=0)
        {
            disp.off();
            print("you are dead");
           // enemy.dead();
            dead.death();
            death_sound.death_sound();
            death_sound.death_sound();
            
        }
        else if (health <= 20)
        {
            vignette.intensity.value = 0.3f;
        }
        else if (health > 20)
        {
            vignette.intensity.value = 0f;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            blood.enabled = false;
            Time.timeScale = 0;
            player.SetActive(false);
            Menu_ui.SetActive(true);
            aim_canva.enabled = false;
            Ammo_canvas.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Instance_Death()
    {
        health = 0f;
        playerhealth(0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Explosive":
                rock.explosive_pick();
                audi.PlayOneShot(pick_clink);
                text1.show("explosive");
                Destroy(Explosive,0.5f);
                break;
            case "Detonator":
                rock.detonator_pick();
                audi.PlayOneShot(pick_clink);
                text1.show("detonator");
                Destroy(Detonator,0.5f);
                break;
            case "medikit":
                health += 25;
                if (health > 100) health = 100;
                text1.show("medikit");
                print("medikit picked");
                audi.PlayOneShot(pick);
                other.gameObject.SetActive(false);
                playerhealth(0f);
                break;
            case "filefolder":
                bos_canas.file_pick();
                audi.PlayOneShot(pick);
                other.gameObject.SetActive(false);
                break;
        }
    }
}
