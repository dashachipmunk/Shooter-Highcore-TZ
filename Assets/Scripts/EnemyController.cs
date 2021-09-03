using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private float timer;

    [Header("References")]
    [SerializeField]
    private Transform player;

    [Header("Health Properties")]
    [SerializeField]
    private float health;

    [Header("Shooting Properties")]
    [SerializeField]
    private float shootingRate;

    [Header("Events")]
    [SerializeField]
    private UnityEvent shooting;

    void Update()
    {
        Shooting();
        transform.LookAt(player.position);
    }

    private void Shooting()
    {
        if (Time.time >= timer)
        {
            timer = Time.time + 1f / shootingRate;
            shooting.Invoke();
        }
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
