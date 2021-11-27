using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_audio_player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        if(currentsceneindex>3 && currentsceneindex <8 )
        {
            Destroy(gameObject);
        }
       
    }
}
