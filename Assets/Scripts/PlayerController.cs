using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    public float speed;

    public float Gravity = 9.8f;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
        //jump
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        //stop if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    private void Update()
    {
        //Movment
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        
        //jump
                if(Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
                {
                   _fallVelocity = -jumpForce;
                }
    }
}