using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting_handler : MonoBehaviour
{
    [SerializeField] GameObject fishes;
    [SerializeField] GameObject water;
    [SerializeField] Canvas setting_canvas;
    [SerializeField] Canvas loading_canva;
    AudioSource adi;
    [SerializeField] AudioClip buton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 

            if(loading_canva!=null)
            loading_canva.enabled = false;
            setting_canvas.enabled = false;
        }
    }
    public void Start()
    {
        adi = GetComponent<AudioSource>();
        
    }
    public void sett()
    {
        setting_canvas.enabled = true; 
    }
    public void audio_play()
    {
        adi.PlayOneShot(buton);
    }
    public void very_low()
    {
        audio_play();
        QualitySettings.SetQualityLevel(0, true);
        fishes.SetActive(false);
        print("verylow");
    }
    public void low()
    {
        audio_play();
        QualitySettings.SetQualityLevel(1, true);
        fishes.SetActive(false);
    }
    public void medium()
    {
        audio_play();
        QualitySettings.SetQualityLevel(2, true);
        fishes.SetActive(false);
    }
    public void high()
    {
        audio_play();
        QualitySettings.SetQualityLevel(3, false); 
       fishes.SetActive(true);
    }
    public void very_high()
    {
        audio_play();
        QualitySettings.SetQualityLevel(4, false);
        fishes.SetActive(true);
    }
    public void ultra()
    {
        audio_play();
        QualitySettings.SetQualityLevel(5, true);
        fishes.SetActive(true);
    }
  

}
