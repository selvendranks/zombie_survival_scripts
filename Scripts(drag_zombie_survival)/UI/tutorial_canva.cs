using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class tutorial_canva : MonoBehaviour
{
    bool next = false;
    bool tut = false;
    menu_handler men;
    [SerializeField] Canvas tutorial_canvas;
    void Start()
    {
        GameObject moment_canvas = transform.GetChild(0).gameObject;
        moment_canvas.SetActive(true);
        men = FindObjectOfType<menu_handler>();
    }
  
    public void tutor()
    {
        tutorial_canvas.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        _activate_basicfn_canvas();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tutorial_canvas.enabled = false;
        }

    }

    void _activate_basicfn_canvas()
    {
        float amount = CrossPlatformInputManager.GetAxis("Horizontal");
      //  print(amount);
        if(amount !=0f )
        {
            next = true;
            GameObject basicfn_canvas = transform.GetChild(1).gameObject;
            basicfn_canvas.SetActive(true);
        }

        if (next == true)
        {
            GameObject moment_canvas = transform.GetChild(0).gameObject;
            moment_canvas.SetActive(false);
            Enter_key();
        }
    }

    void Enter_key()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            men.menu();
            gameObject.SetActive(false);
            tut = true;
           
        }
    }
}
