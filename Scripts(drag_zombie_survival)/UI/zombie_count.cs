using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie_count : MonoBehaviour
{
    train_controller train;
    Text count;
    void Start()
    {
        train = FindObjectOfType<train_controller>();
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display_count();
    }
    public void display_count()
    {
        int num = train.child_count();
        count.text = num.ToString();
    }
}
