using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public AudioSource AudioSource;

    public float SoundPitch = 1f;

    public float IdleSpeed = 10f;

    public float ForwardSpeed = 30f;
    public float RotationSpeed = 4f;
    public GameObject GameOver;
    public GameObject Win;
    public int CoinCount = 8;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

   
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.2f);
    }*/

    
    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * ForwardSpeed + IdleSpeed;

        _rigidbody.AddRelativeForce(0f, 0f, forwardForce, ForceMode.Acceleration);
        _rigidbody.AddRelativeTorque(sideForce, 0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            SoundPitch = Mathf.Lerp(SoundPitch, 1.5f, Time.deltaTime);
        }
        else
        {
            SoundPitch = Mathf.Lerp(SoundPitch, 1f, Time.deltaTime);
        }
    }

    private void Update()
    {
        AudioSource.pitch = SoundPitch;
        if (CoinCount == 0)
        {
            Destroy(gameObject);
            Win.SetActive(true);
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.name == "Bomb")
        {
            Destroy(gameObject);
            GameOver.SetActive(true);
            
        }
        else
        {
            CoinCount--;
        }
    }


}