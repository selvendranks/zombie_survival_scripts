using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu_sound : MonoBehaviour
{
    AudioSource adi;
    void Start()
    {
        adi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   

        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
       
        if (currentsceneindex <= 3)
        {
            DontDestroyOnLoad(this.gameObject);
            if (!adi.isPlaying)
                adi.Play();
        }
        else
        {
            adi.Stop();
            Destroy(gameObject);
        }
    }
  
}
