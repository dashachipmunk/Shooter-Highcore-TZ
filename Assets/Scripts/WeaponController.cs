using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float timer;

    [Header("Preperties")]
    public int damage;
    [SerializeField]
    private Sprite weaponSprite;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float shootingRange;
    [SerializeField]
    private float shootingRate;

    public void OnShoot()
    {
        if (Time.time >= timer)
        {
            GameObject bullet = Instantiate(bulletPrefab, shotPosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
            bullet.transform.parent = gameObject.transform;
            timer = Time.time + 1f / shootingRate;
            Destroy(bullet, shootingRange);
        }
    }
}
