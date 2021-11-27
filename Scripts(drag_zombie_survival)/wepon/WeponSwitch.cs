using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class WeponSwitch : MonoBehaviour
{
    [SerializeField] int currentwep = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setweponactive();
        processkey();
        processscroll();

    }

    private void processscroll()
    {
       if((CrossPlatformInputManager.GetAxis("Mouse ScrollWheel")>0))
        {
            if(currentwep >= transform.childCount-1)
            {
                currentwep = 0;
            }
            else
            {
                currentwep++;
            }
        }
        if ((CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") < 0))
        {
            if (currentwep <= 0)
            {
                currentwep = 3;
            }
            else
            {
                currentwep--;
            }
        }
    }

    private void processkey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentwep = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentwep = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentwep = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentwep = 3;
        }
       
    }

    void setweponactive()
    {
        int weponindex = 0;

        foreach(Transform Weapons in transform)
        {
            if(weponindex==currentwep)
            {
                Weapons.gameObject.SetActive(true);
            }
            else
            {
                Weapons.gameObject.SetActive(false);
            }
            weponindex++;
        }

    }
 
}
