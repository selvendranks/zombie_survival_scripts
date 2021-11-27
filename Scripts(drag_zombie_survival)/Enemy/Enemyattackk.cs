using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattackk : MonoBehaviour
{
  
    PlayerHealth Target;
    [SerializeField] float damage = 10f;
  

    private void Start()
    {
      
        Target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
      
        if (Target == null) return;
        Target.playerhealth(damage);
      
        print("Bang bang");

    }
}
