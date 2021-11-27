using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] Transform target;
    [SerializeField] float chasedist = 5f;
    [SerializeField] float turnspeed = 5f;
    [SerializeField] AudioClip zomie;
   // bool provoked = false;
    float distancebetw;
    NavMeshAgent nav;
    bool onshot=false;
    EnemyHealth heal;
    bool canshout = true;
    void Start()
    {
        adi = GetComponent<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
        heal = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
       
        distancebetw = Vector3.Distance(target.position, transform.position);
        if(heal.Isdead()==true)
        {
           
          //  enabled = false;
          //  nav.enabled = false;
        }
        if (distancebetw <= chasedist||onshot==true)
        {
           
            Engagetarget();
        }


        else if(onshot==false)
        {
            adi.Stop();
            GetComponent<Animator>().SetBool("Idle", true);
            GetComponent<Animator>().SetBool("Move", false);
        }

     
    }

    public void OnDamage()
    {
        onshot = true;
        chase();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasedist);
    }


    void Engagetarget()
    {
        if (!adi.isPlaying && canshout == true)
        {
            canshout = false;
            adi.PlayOneShot(zomie);
            Invoke("shout", 4f);
        }
        facetarget();
        if (distancebetw > nav.stoppingDistance)
        {
            chase();
        }

        else if (distancebetw <= nav.stoppingDistance)
        {
            attack();
        }
    }

    void chase()
    { 
     
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetBool("Idle", false);
        GetComponent<Animator>().SetBool("Move",true);
        
        nav.SetDestination(target.position);
    }
     
    void attack()
    {
        
        GetComponent<Animator>().SetBool("Attack", true);
       
    }
    void facetarget()
    {
        Vector3 Direction = (target.position - transform.position).normalized;
        Quaternion Lookrotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Lookrotation, Time.deltaTime * turnspeed);
    }

   public  void dead()
    {
        print("dead");
        
    }
    void shout()
    {
        canshout = true;
    }
}