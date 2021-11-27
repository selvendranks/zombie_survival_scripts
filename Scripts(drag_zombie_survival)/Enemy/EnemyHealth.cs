using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Healthtext Health;
    [SerializeField] float hitpoints = 500f;
    bool isdead = false;
    [SerializeField] GameObject[] objects;
    public void Start()
    {
        Health = FindObjectOfType<Healthtext>();
    }

    public bool Isdead()
    {
        return isdead;
    }
    public void TakeDamage( float damage)
    {
        hitpoints = hitpoints - damage;
        BroadcastMessage("OnDamage");

        if(hitpoints<=0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isdead == true) return;
        isdead = true; 
        GetComponent<Animator>().SetTrigger("die");
        int num = Random.Range(0, 5);
            Instantiate(objects[num], transform.position + new Vector3(0, 0.4f, 0f), Quaternion.identity);
        Destroy(gameObject,1.5f);
    }
}
