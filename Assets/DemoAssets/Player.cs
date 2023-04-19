using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] float groundCheckDistance = 0.1f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (isOnGround)
        {
            rb.AddForce(move * moveSpeed);
            if (Input.GetAxis("Jump") > 0)
            {
                rb.AddForce(transform.up * jumpForce);
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private bool isOnGround
    {
        get
        {
            return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance);
        }
    }
}
