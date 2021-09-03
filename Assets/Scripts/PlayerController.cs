using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
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

    [Header("Events")]
    [SerializeField]
    private UnityEvent shooting;

    private void Awake()
    {
        healthBarSlider.maxValue = health;
        healthBarSlider.value = healthBarSlider.maxValue;
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
            moveDirection.Normalize();
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
    }

    private void Rotating()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
    }

    private void Shooting()
    {
        if (Input.GetButton("Fire1"))
            shooting.Invoke();
    }

    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        health = healthBarSlider.value;
        PlayerDies();
    }

    private void PlayerDies()
    {
        if (health <= 0)
            StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
