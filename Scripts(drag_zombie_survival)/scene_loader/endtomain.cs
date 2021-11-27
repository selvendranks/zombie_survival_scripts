using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endtomain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("next", 40f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void next()
    {
        SceneManager.LoadScene(3);
    }
}
