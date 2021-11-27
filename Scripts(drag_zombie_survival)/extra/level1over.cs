using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level1over : MonoBehaviour
{
    BoxCollider coll;
    light_system torch;
    [SerializeField] Canvas level1over_canvas;
    void Start()
    {
        coll = GetComponent<BoxCollider>();
        torch = FindObjectOfType<light_system>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (torch.lighton_or_off() == true)
                {
                    level1over_canvas.enabled = true;
                    print("colliding");
                    Invoke("next", 15f);
                    coll.enabled = false;
                    //Destroy(gameObject);
                }
                break;
        }
    }
void next()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex + 1);
    }
}
