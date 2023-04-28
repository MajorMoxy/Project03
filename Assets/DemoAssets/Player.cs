using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float skinWidth = 0.1f;
    [SerializeField] private LayerMask layerMask;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CheckGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (CheckGrounded())
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);
        }
    }

    private bool CheckGrounded()
    {
        Vector3 boxSize = new Vector3(transform.localScale.x * GetComponent<BoxCollider>().size.x - skinWidth * 2f,
                                       skinWidth * 2f,
                                       transform.localScale.z * GetComponent<BoxCollider>().size.z - skinWidth * 2f);
        Vector3 boxCenter = transform.position - Vector3.up * (GetComponent<BoxCollider>().size.y / 2f - skinWidth);
        float maxDistance = 0.1f;
        bool hitGround = Physics.BoxCast(boxCenter, boxSize / 2f, -Vector3.up, out RaycastHit hitInfo, Quaternion.identity, maxDistance, layerMask, QueryTriggerInteraction.Ignore);
        Vector3 rayOrigin = transform.position - Vector3.up * (GetComponent<BoxCollider>().size.y / 2f - skinWidth);
        float rayDistance = skinWidth * 2f;
        hitGround |= Physics.Raycast(rayOrigin, -Vector3.up, rayDistance, layerMask, QueryTriggerInteraction.Ignore);

        return hitGround;
    }
}
