using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool _enabled;
    private Rigidbody rb;
    public bool Enabled { get => _enabled; set => _enabled = value; }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_enabled)
        {
            Rotate();
        }
    }

    public void Rotate()
    {

        rb.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime, Space.World);
    }

    public void ModifySpeed(float speed)
    {
        rotationSpeed = speed;
    }


}
