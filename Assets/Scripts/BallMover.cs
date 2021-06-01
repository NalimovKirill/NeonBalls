using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Rigidbody _rb;

    public LayerMask collisionMask;

    private float _speed = 5;
    private Vector3 _direction;

    private Vector3 _lastVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _direction = Random.insideUnitCircle.normalized;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
       // _rb.AddForce(transform.position + _speed * _direction * Time.deltaTime, ForceMode.Acceleration);
        _rb.velocity = _speed * (_rb.velocity.normalized);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * _speed + .1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);

            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, rot, 0);
        }

    }

   
}
