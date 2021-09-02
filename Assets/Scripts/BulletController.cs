using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody rigidBody;

    [SerializeField]
    private float bulletSeed;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidBody.velocity = transform.forward * bulletSeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
