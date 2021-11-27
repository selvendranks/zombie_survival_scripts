using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_damage : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] AudioClip damage_recieved;
    [SerializeField] Canvas impactcanvas;
    [SerializeField] float impacttime = 0.3f;
    void Start()
    {
        adi = GetComponent<AudioSource>();
        impactcanvas.enabled = false;
      
    }

    
    void Update()
    {
        
    }

   public void showdamage()
    {
        adi.PlayOneShot(damage_recieved);
        StartCoroutine(showblood());
        print("showing");
    }

    IEnumerator showblood ()
    {
        impactcanvas.enabled = true;
        yield return new WaitForSeconds (impacttime);
        impactcanvas.enabled = false;
    }

    public void off()
    {
        impactcanvas.enabled = false;
    }
}
