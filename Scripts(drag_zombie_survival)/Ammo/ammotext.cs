using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ammotext : MonoBehaviour
{
    
    Text ammutext;
    bool reload = true;
    // Start is called before the first frame update
    void Start()
    {
        ammutext = GetComponent<Text>();
        ammutext.text = "999";

    }

    // Update is called once per frame
    public void showammo(int inmag, int outmag)
    {
        ammutext.text = inmag.ToString() + "/" + (outmag).ToString();
    }
}
