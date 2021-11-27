using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_controller : MonoBehaviour
{
    AudioSource adi;
    bogi_controller bogi;
    [SerializeField] GameObject Player_camera;
    [SerializeField] GameObject Train_camera;
    [SerializeField] GameObject zombies;
    [SerializeField] AudioClip door_sound;
    [SerializeField] GameObject boarded;
    [SerializeField] GameObject kill_all;
    bool killed_all;
    Animation door_open;
      void Start()
    {
        adi = GetComponent<AudioSource>();
        bogi = FindObjectOfType<bogi_controller>();
        door_open = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(zombies.transform.childCount == 0)
        {
            killed_all = true;
        }
        inrange();
    }

 void inrange()
    {
        float Dist = Vector3.Distance(transform.position, Player_camera.transform.position);
        if (Input.GetKeyDown(KeyCode.Return)&&Dist<12f)
        {
            if (killed_all == true)
            {
                adi.PlayOneShot(door_sound);
                door_open.Play();
                Invoke("change_camera", 3f);
                bogi.train_horn();
                bogi.train_movement();
                boarded.SetActive(true);
                Invoke("hide", 7f);
            }
            else
            {
                kill_all.SetActive(true);
                Invoke("hide", 7f);
            }
        }
    }
void change_camera()
    {
        Player_camera.SetActive(false);
    }
public int child_count()
    {
        return zombies.transform.childCount;
    }
void hide()
    {
        boarded.SetActive(false);
        kill_all.SetActive(false);
    }
}
