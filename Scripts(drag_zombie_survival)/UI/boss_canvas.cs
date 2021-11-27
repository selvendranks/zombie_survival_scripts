using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class boss_canvas : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] GameObject hero_audio;
    [SerializeField] GameObject hero_canvas;
    [SerializeField] GameObject blockage;
    [SerializeField] GameObject general_audio;
    [SerializeField] GameObject boss_audio;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject player;
    [SerializeField] GameObject basement;
    [SerializeField] GameObject beds;
    [SerializeField] GameObject reserch;
    [SerializeField] GameObject text_basement;
    [SerializeField] GameObject text_beds;
    [SerializeField] GameObject text_reserch;
    [SerializeField] GameObject text_file_picked;
    bool doc_picked = false;
    bool basement_looked = false;
    bool beds_looked = false;
    bool reseach_looked = false;
    bool played_once = false;
    void Start()
    {
        adi = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (boss == null) { 
            boss_audio.SetActive(false); 
            hero_audio.SetActive(true);
            hero_canvas.SetActive(true);
            Invoke("next", 15f);

        }
        if (Vector3.Distance(player.transform.position, boss.transform.position) < 30f && doc_picked == true)
            blockage.SetActive(true);
        seedistance();
    }

    public void seedistance()
    {   
        float distpl_bas = Vector3.Distance(player.transform.position, basement.transform.position);
        float distpl_bed = Vector3.Distance(player.transform.position, beds.transform.position);
        float distpl_res = Vector3.Distance(player.transform.position, reserch.transform.position);
        if (distpl_bas < 5f&& basement_looked == false)
        {
           
            text_basement.SetActive(true);
            basement_looked = true;
           
       }
        if (distpl_bed < 5f && beds_looked==false)
        {
            text_basement.SetActive(false);
            text_beds.SetActive(true);
            beds_looked = true;
            
        }
        if (distpl_res < 5f && reseach_looked==false)
        {
            text_beds.SetActive(false);
            text_reserch.SetActive(true);
            reseach_looked = true;
            Invoke("hide", 10f);
        }
        if (distpl_bas < 5f && doc_picked == true && played_once == false)
        {
            played_once = true ;
            boss.SetActive(true);
            Camera.SetActive(true);
            MainCamera.SetActive(false);
            Invoke("sound", 2f);
            Invoke("camera_active", 3f);
        }

    }

public void hide()
    {
        text_basement.SetActive(false);
        text_beds.SetActive(false);
        text_reserch.SetActive(false);
       
    }
public void file_pick()
    {
        doc_picked = true;
        hide();
        text_file_picked.SetActive(true);
        Invoke("hide2", 10f);
    }
public void hide2()
    {
        text_file_picked.SetActive(false);
    }
void camera_active()
    {
        MainCamera.SetActive(true);
        general_audio.SetActive(false);
        boss_audio.SetActive(true);
        
    }
void sound()
    {if(!adi.isPlaying)
        adi.Play();
    }

void next()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex + 1);
    }
}
