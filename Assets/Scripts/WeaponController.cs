using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float timer;
    private int bulletsNumber;

    [Header("Public Properties")]
    public int damage;
    public int maxBulletsNumber;
    public Sprite weaponSprite;

    [Header("Properties")]
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
    [SerializeField]
    private float reloadingSpeed;

    public void OnShoot()
    {
        if (Time.time >= timer)
        {
            GameObject bullet = Instantiate(bulletPrefab, shotPosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
            bullet.transform.parent = gameObject.transform;
            timer = Time.time + 1f / shootingRate;
            bulletsNumber--;
            if (bulletsNumber <= 0)
                StartCoroutine(Reload());
            Destroy(bullet, shootingRange);
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadingSpeed);
        bulletsNumber = maxBulletsNumber;
    }
}
