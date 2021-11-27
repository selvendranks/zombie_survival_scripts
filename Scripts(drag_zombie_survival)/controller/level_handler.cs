using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level_handler : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        adi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void level1()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void level2()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void level3()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
    public void level4()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
}
