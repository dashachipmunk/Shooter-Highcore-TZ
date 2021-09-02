using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float timer;

    [Header("References")]
    [SerializeField]
    private GameObject player;

    [Header("Health Properties")]
    [SerializeField]
    private int health;

    [Header("Shooting Properties")]
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private float shootingFrequency;

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
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            LeanPool.Spawn(shot, shotPosition.position, transform.rotation);
            timer = shootingFrequency;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerShot"))
        {
            health--;
            Destroy(other.gameObject);
            EnemyDies();
        }
    }

    private void EnemyDies()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
