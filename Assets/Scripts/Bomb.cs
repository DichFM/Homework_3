using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform Airplane;

    public float RotateSpeed = 5f;
    public float Speed = 20f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        _rigidbody.AddRelativeForce(0f, 0f, Speed);
        

    }

    private void Update()
    {
        /*Vector3 direction = Airplane.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);*/
        
        float Speed = RotateSpeed * Time.fixedDeltaTime;
        transform.LookAt(Airplane );

    }
}
