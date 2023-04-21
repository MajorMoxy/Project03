using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _enabled;
    private Vector3 _rotation;

    public bool Enabled { get => _enabled; set => _enabled = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_enabled)
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        _rotation = new Vector3(0, 0, _rotationSpeed);
        _rb.AddTorque(_rotation);
    }
}
