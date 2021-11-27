using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossai : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] GameObject[] objects;
    [SerializeField] Transform target;
    [SerializeField] float chasedist = 5f;
    [SerializeField] float turnspeed = 5f;
    [SerializeField] AudioClip zomie;
    // bool provoked = false;
    bool can_instantiate = true;
    float distancebetw;
    NavMeshAgent nav;
    bool onshot = false;
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
        if (can_instantiate == true)
        {
            can_instantiate = false;
            int num = Random.Range(0, 3);
            if(num ==1)
                Instantiate(objects[num], transform.position + new Vector3(0, 0.4f, 0f), Quaternion.identity);
            else
                Instantiate(objects[num], transform.position + new Vector3(0, 0.2f, 0f), Quaternion.identity);
            Invoke("inst", 10f);
        }
        distancebetw = Vector3.Distance(target.position, transform.position);
        if (heal.Isdead() == true)
        {

            //  enabled = false;
            //  nav.enabled = false;
        }
        if (distancebetw <= chasedist || onshot == true)
        {

            Engagetarget();
        }


        else if (onshot == false)
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
        if (!adi.isPlaying && canshout == true)
        {
            canshout = false;
            adi.PlayOneShot(zomie);
            Invoke("shout", 6f);
        }
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("Move", true);

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

        void inst()
        {
            can_instantiate = true;
        }

       void shout()
    {
        canshout = true;
    }
    }

