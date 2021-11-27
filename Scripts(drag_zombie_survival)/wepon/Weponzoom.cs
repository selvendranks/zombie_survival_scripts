using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
public class Weponzoom : MonoBehaviour
{
  //  [SerializeField] GameObject player;
    [SerializeField] GameObject aim;
    [SerializeField] GameObject scope;
    [SerializeField] Camera field;
   FirstPersonController freelook;
    [Header("zoom")]
   [SerializeField] float zoom=20f;
    [SerializeField] float normal = 60f;
    [Header("freelook")]
    [SerializeField] float zoomlook = 1f;
    //[SerializeField] float normallook = 2f;
    void Start()
    {
        field = field.GetComponent<Camera>();
        freelook = FindObjectOfType<FirstPersonController>();
       
    }

    // Update is called once per frame
    void Update()
    {
            initiatezoom();
    }

    void initiatezoom()
    {
        if (Input.GetMouseButton(1))
        {
            processzoom();
        }
        else
        {
            aim.SetActive(true);
            scope.SetActive(false);
            field.fieldOfView = normal;
            freelook.m_MouseLook.XSensitivity= 6f;
            freelook.m_MouseLook.YSensitivity = 4f;

          
            
        }
    }

    void processzoom()
    {
        aim.SetActive(false);
        scope.SetActive(true);
        field.fieldOfView = zoom;
        freelook.m_MouseLook.XSensitivity = zoomlook;
        freelook.m_MouseLook.YSensitivity = zoomlook; 
    }
}
