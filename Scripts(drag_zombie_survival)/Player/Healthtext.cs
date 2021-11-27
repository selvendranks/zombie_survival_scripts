using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthtext : MonoBehaviour
{
   // int Health;
    Text HealthText;
    void Start()
    {
        HealthText = GetComponent<Text>();
        HealthText.text = "100";
    }

    // Update is called once per frame
  
   public  void showhealth(float health)
    {
        HealthText.text = health.ToString();
        if(health<0)
        {
            HealthText.text = "Dead";
        }
      
    }
}
