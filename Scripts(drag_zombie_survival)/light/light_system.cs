using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_system : MonoBehaviour
{
    AudioSource audi;
    [SerializeField] float intensity= 0.03f;
    [SerializeField] float lightangle= 0.003f;
    [SerializeField] float minimumangle = 40f;
    [SerializeField] AudioClip click;
    bool toggled = false;
    Light ligh;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        ligh = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        toggle();
        if (toggled == true)
        {
            reduce_angle();
            reduce_intensity();
        }
    }

    void reduce_angle()
    {
        if (ligh.spotAngle > minimumangle)
            ligh.spotAngle -= lightangle * Time.deltaTime;

        else return;
    }

    void reduce_intensity()
    {
        ligh.intensity -= intensity * Time.deltaTime;
    }

    public void _restore_intensity()
    {
        ligh.intensity = 15f;
    }

    public void restore_angle()
    {
        ligh.spotAngle = 70f;
    }
    void toggle()
    { 

        if (Input.GetKeyDown(KeyCode.T))
        {
            audi.PlayOneShot(click);
            toggled = !toggled;
            ligh.enabled = toggled;
        }
    }
    public bool lighton_or_off()
    {
        return toggled;
    }
}
