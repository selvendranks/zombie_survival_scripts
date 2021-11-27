using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rock_explode : MonoBehaviour
{
    AudioSource Audio;
    MeshRenderer mesh;
    BoxCollider box;
    PlayerHealth health;
    [SerializeField] AudioClip Explosion;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tunnel;
    [SerializeField] Canvas Find_Explosive;
    [SerializeField] Canvas Find_Denotor;
    [SerializeField] Canvas Safe_distance;
    [SerializeField] Canvas Too_far;
    [SerializeField] GameObject c4_pick;
    [SerializeField] GameObject c4_plant;
    [SerializeField] GameObject detonator;
    [SerializeField] ParticleSystem explosion;
    bool found_path=false;
    bool explosive_picked= false;
    bool detonator_picked= false;
    bool explosive_planted = false;
    bool rock_destroyed = false;
    bool once_showed = false;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
        box = GetComponent<BoxCollider>();
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Foun_denotor();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (found_path == false)
                {
                    Find_Explosive.enabled = true;
                    c4_pick.SetActive(true);
                    found_path = true;
                    Invoke("hide", 15f);
                }

                if(found_path==true&&explosive_picked==true&&explosive_planted==false)
                {
                    explosive_planted = true;
                    c4_plant.SetActive(true);
                    detonator.SetActive(true); 
                    Find_Denotor.enabled = true;
                    Invoke("hide", 15f);

                }

                break;

        }

    }
    void Foun_denotor()
    {
        if(detonator_picked== true)
        {
            if (once_showed == false)
            {
                Safe_distance.enabled = true;
                Invoke("hide", 15f);
                once_showed = true;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                float dist2 = Vector3.Distance(transform.position, player.transform.position);
              
                if (dist2 < 100f)
                {
                    Audio.PlayOneShot(Explosion);
                    explosion.Play();
                    float dist = Vector3.Distance(transform.position, player.transform.position);
                    if (dist < 50f)
                        health.Instance_Death();
                    Destroy(c4_plant);
                    //gameObject.SetActive(false);
                    mesh.enabled = false;
                    box.enabled = false;

                    rock_destroyed = true;
                }
                else
                {
                    Safe_distance.enabled = false;
                    Too_far.enabled = true;
                    Invoke("hide", 15f);
                }
            }
            if (rock_destroyed == true)
            {
                float dist1 = Vector3.Distance(tunnel.transform.position, player.transform.position);
                if (dist1 < 10f)
                {
                    int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(currentsceneindex+1);
                }
            }

        }
    }
 public void explosive_pick()
    {
        explosive_picked = true;
    } 
 public void detonator_pick()
    {
        detonator_picked = true;
    }

 void hide()
    {
        Find_Explosive.enabled = false;
        Find_Denotor.enabled = false;
        Safe_distance.enabled = false;
        Too_far.enabled = false;
    }
}
