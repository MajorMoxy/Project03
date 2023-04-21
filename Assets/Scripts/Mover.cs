using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _verticalFoce;
    [SerializeField] private bool _enabled;

    private Vector3 _horizontal;
    private Vector3 _vertical;

    public bool Enabled { get => _enabled; set => _enabled = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_enabled)
        {
            MoveAbsolute();
        }
    }

    public void MoveAbsolute()
    {
        _horizontal = new Vector3(_horizontalForce, 0, 0);
        _vertical = new Vector3(0, _verticalFoce, 0);

        _rb.AddForce(_horizontal);
        _rb.AddForce(_vertical);
    }
}
