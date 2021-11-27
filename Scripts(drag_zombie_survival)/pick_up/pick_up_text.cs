using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pick_up_text : MonoBehaviour
{
    Text pick_text;
    void Start()
    {
        
        pick_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

 public   void show(string ammo)
    {
        if (string.Compare(ammo,"battery")==0)
        {
            print("picked");
            pick_text.text = "picked up torchlight battery";
            Invoke("hide", 3f);
        }
        if(string.Compare(ammo, "medikit") == 0)
        {
            pick_text.text = "picked up medikit";
            Invoke("hide", 3f);
        }
        if(string.Compare(ammo, "detonator") == 0)
        {
            pick_text.text = "picked up detonator";
            Invoke("hide", 4f);
        }
        if (string.Compare(ammo, "explosive") == 0)
        {
            pick_text.text = "picked up explosive";
            Invoke("hide", 4f);
        }
        else
        {
            pick_text.text = "picked up " + ammo + " refill";
            Invoke("hide", 3f);

        }
    }

    void hide()
    {
        pick_text.text = "";
    }

}
