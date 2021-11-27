using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class boatcontroller : MonoBehaviour
{
    float xthrow;
    AudioSource audi;
    [Tooltip("In ms^-1")] [SerializeField] float speed = 4f;
    Rigidbody rbody;
    [SerializeField] GameObject player_camera;
   // [SerializeField] Vector3 player_camer;
    [SerializeField] GameObject boat_camera;
    [SerializeField] AudioClip thrust_sound;
    [SerializeField] GameObject aim;
    public float turnSpeed = 1000f;
    public float accellerateSpeed = 1000f;
    bool inboat = false;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&inboat==true)
        {
            aim.SetActive(true);
            audi.Stop();
            player_camera.transform.localPosition = gameObject.transform.localPosition + new Vector3(0,0f,0);
            player_camera.SetActive(true);
            boat_camera.SetActive(false);
            rbody.isKinematic = true;
            inboat = false;
        }
        if (inboat == true)
        {
            controlboat();
        }
        print(inboat);
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                if (Input.GetKeyDown(KeyCode.Return))
                    {
                    aim.SetActive(false);
                    player_camera.SetActive(false);
                    boat_camera.SetActive(true);
                    rbody.isKinematic = false;
                    inboat = true;
                }
              
                break;
        }
    }

void controlboat()
    {
        boat_thrust();
        boat_rotate();
    }
void boat_thrust()
    {
       

    }
 void   boat_rotate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!audi.isPlaying)
                audi.PlayOneShot(thrust_sound);
        }
        else
            audi.Stop();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rbody.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);
        rbody.AddForce(transform.forward * v * accellerateSpeed * Time.deltaTime);
    }
}
