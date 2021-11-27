using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;

public class launch_grenade : MonoBehaviour
{
    [SerializeField] Transform spawnpoint;
    [SerializeField] GameObject grenade;
    [SerializeField] float range;
   [SerializeField] ammotypes ammo;
    Ammo am;
    ammotext amu;
    void Start()
    {
        amu = FindObjectOfType<ammotext>();
        am = FindObjectOfType<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        amu.showammo(am.GetCurrentAmmo(ammo),0);
        if (Input.GetButtonDown("Fire1") && am.GetCurrentAmmo(ammo) > 0) 
            launch();
    }

    void launch()
    {
        am.ReduceCurrentAmmo(ammo);
        spawnpoint.position += new Vector3(10f, 0f, 0f);
        GameObject grenadeinstance = Instantiate(grenade, spawnpoint.position, spawnpoint.rotation);
        grenadeinstance.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * range, ForceMode.Impulse);
    }
}