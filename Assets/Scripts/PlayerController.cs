using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputController _playerInput;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private Transform _cameraMain;
    private Animator _animator;
    
    [SerializeField] private float playerSpeed = 2.0f;
    //[SerializeField] private float jumpHeight = 1.0f;
    //[SerializeField] private float gravityValue = -9.81f;
    //[SerializeField] private float rotationSpeed = 4f;
    
    private void Awake()
    {
        _playerInput = new PlayerInputController();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    

    private void Start()
    {
        _cameraMain = Camera.main.transform;
    }

    void Update()
    {
        /*_groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }*/


        Vector2 movementInput = _playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y );
        move = _cameraMain.forward * move.z + _cameraMain.right * move.x;
        move.y = 0f;
        _controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

            if (move.z < 1)
            {
                _animator.SetFloat("VelocityZ", Mathf.Abs(move.z)); 
            }

            if (move.x < 1)
            {
                _animator.SetFloat("VelocityX", Mathf.Abs(move.x));
            }
            
        }

        /*if (move == Vector3.left)
        {
            _animator.SetFloat("Velocity", move.x);
        }*/
        
        /*********** MOUSE CONTROL LOOK ***********/
        /*if (movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg + _cameraMain.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }*/
        
        /*******************JUMP********************/
        // Changes the height position of the player..
        /*if (_playerInput.Player.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        /*playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);*/
    }
}
