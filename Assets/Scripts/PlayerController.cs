using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float timer;

    [Header("References")]
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private Slider healthBarSlider;

    [Header("Moving Properties")]
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    [Header("Health Properties")]
    [SerializeField]
    private float health;

    [Header("Shooting Properties")]
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private float shootingFrequency;

    [Header("Events")]
    [SerializeField]
    private UnityEvent<int> playerIsShot;

    private void Awake()
    {
        healthBarSlider.maxValue = health;
    }

    private void Update()
    {
        Moving();
        Rotating();
        Shooting();
    }

    private void Moving()
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

    private void Rotating()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
    }

    private void Shooting()
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

    private void ReduceHealth(int damage)
    {
        healthBarSlider.value -= damage;
        health = healthBarSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyShot"))
        {
            ReduceHealth(2);
            Destroy(other.gameObject);
        }
    }
}
