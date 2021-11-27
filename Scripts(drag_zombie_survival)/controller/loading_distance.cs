using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading_distance : MonoBehaviour
{
    [SerializeField] float load_distance;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loadin_distance();
    }

    void loadin_distance()
    {
        int fish_index = 0;
        foreach (Transform fishes in transform)
        {
            float dist = Vector3.Distance(player.transform.position, fishes.gameObject.transform.position);

            if (load_distance>dist)
            {
                fishes.gameObject.SetActive(true);
            }
            else
            {
                fishes.gameObject.SetActive(false);
            }
            fish_index++;
        }
    }
}
