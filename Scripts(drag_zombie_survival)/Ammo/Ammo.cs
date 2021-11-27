using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    light_system _light_;
    [SerializeField] ammoslot[] ammoslots;
    [System.Serializable]
   
    public class ammoslot
    {  
        public ammotypes ammotype;
        public int ammoamount;
    }

    private void Start()
    {
        _light_ = FindObjectOfType<light_system>();
    }
    public int GetCurrentAmmo(ammotypes ammo)
    {
        return Gettype(ammo).ammoamount;
    }
    public void ReduceCurrentAmmo(ammotypes ammo)
    {
       Gettype(ammo).ammoamount--;
    }
    public void addammo(ammotypes ammo)
    {
        if (Gettype(ammo).ammotype == ammotypes.revolver)
        {
            Gettype(ammo).ammoamount += 6;
        }
        else if (Gettype(ammo).ammotype == ammotypes.shotgun)
        {
            Gettype(ammo).ammoamount += 5;
        }
        else if (Gettype(ammo).ammotype == ammotypes.rifle)
        {
            Gettype(ammo).ammoamount += 30;
        }
        else if (Gettype(ammo).ammotype == ammotypes.sniper)
        {
            Gettype(ammo).ammoamount += 5;
        }
       

    }
    public ammoslot Gettype(ammotypes ammo)
    {
        foreach (ammoslot amu in ammoslots)
        {
            if (amu.ammotype == ammo)
            {
                return amu;
            } 
        }
        return null;

    }
}