using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class MovementCamera : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0.5f;
    private Vector3 moveVector;
    public LayerMask GroundLayer = 1;
    private CapsuleCollider _collider;
  
    private bool IsGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);
            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
        }
    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);              
    }
  
}

