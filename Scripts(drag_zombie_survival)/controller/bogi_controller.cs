using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bogi_controller : MonoBehaviour
{
    Animation train_move;
    AudioSource adi;
    [SerializeField] AudioClip movement;
    [SerializeField] AudioClip horn;
     // Start is called before the first frame update
    void Start()
    {
        train_move = GetComponent<Animation>();
        adi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void train_horn()
    {
        Invoke("t1", 4f);
    }
public void train_movement()
    {
        Invoke("t2",7.5f);
    }
void t1()
    {
        adi.PlayOneShot(horn);
    }
void t2()
    {
        train_move.Play();
        Invoke("next",25f);
        adi.PlayOneShot(movement);
    }
void next()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex + 1);
    }
}
