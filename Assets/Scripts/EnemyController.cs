
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float timer;

    [Header("References")]
    [SerializeField]
    private GameObject player;

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
    private UnityEvent shooting;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Shooting();
        transform.LookAt(player.transform.position);
    }

    private void Shooting()
    {
        shooting.Invoke();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        EnemyDies();
    }

    private void EnemyDies()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
