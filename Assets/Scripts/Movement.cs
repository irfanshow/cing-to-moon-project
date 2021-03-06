using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource sfx;

    [SerializeField]float thrustPower;
    [SerializeField]float thrustRotationPower;
    [SerializeField]AudioClip kucingEngine;
    [SerializeField]ParticleSystem kucingThrustParticle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        RotationControl();
        ThrustControl();
    }

    void RotationControl()
    {
        if(Input.GetKey(KeyCode.W))
        {
            RocketRotation(-thrustRotationPower);
        }

        else if(Input.GetKey(KeyCode.S))
        {
            RocketRotation(thrustRotationPower);
        }
    }

    void ThrustControl()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
            if(!sfx.isPlaying)
            {
                sfx.PlayOneShot(kucingEngine);
            }

             if(!kucingThrustParticle.isPlaying)
            {
                kucingThrustParticle.Play();
            }
            
            
        }

        else{
            sfx.Stop();
            kucingThrustParticle.Stop();
        }
    }

    void RocketRotation(float rotationVar)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationVar * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
