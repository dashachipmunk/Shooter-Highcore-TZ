using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        PlayerWeaponController playerWeaponController = GetComponentInParent<PlayerWeaponController>();
        EnemyWeaponController enemyWeaponController = GetComponentInParent<EnemyWeaponController>();
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (playerWeaponController != null)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(playerWeaponController.Damage);
                Destroy(gameObject);
            }
        }
        else if (enemyWeaponController != null)
        {
            if (player != null)
            {
                player.TakeDamage(enemyWeaponController.Damage);
                Destroy(gameObject);
            }
        }
    }
}
