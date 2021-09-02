using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float timer;

    [Header("References")]
    [SerializeField]
    private CharacterController characterController;

    [Header("Moving Properties")]
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    [Header("Shooting properties")]
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private float shootingFrequency;

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
        Rotate();
        Shoot();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && timer <= 0)
        {
            LeanPool.Spawn(shot, shotPosition.position, transform.rotation);
            timer = shootingFrequency;
        }
    }
}
