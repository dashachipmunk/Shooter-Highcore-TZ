using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        WeaponController weaponController = GetComponentInParent<WeaponController>();
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (weaponController != null)
        {
            if (enemy != null)
            {
                enemy.TakeDamage(weaponController.damage);
            }
            else if (player != null)
            {
                player.TakeDamage(weaponController.damage);
            }
            Destroy(gameObject);
        }
    }
}
