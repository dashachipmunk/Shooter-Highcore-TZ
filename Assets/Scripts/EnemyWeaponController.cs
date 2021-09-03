using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWeaponController : MonoBehaviour
{
    private float timer;
    private int weaponIndex;
    public int damage;

    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shotPosition;
    [SerializeField]
    private GameObject[] weapons;

    private void Awake()
    {
        weaponIndex = Random.Range(0, weapons.Length);
        ChangeWeaponInformation(weaponIndex);
    }

    public void OnShoot()
    {
        if (Time.time >= timer)
        {
            WeaponManager weaponManager = weapons[weaponIndex].GetComponent<WeaponManager>();
            if (weaponManager != null)
            {
                if (weaponManager.bulletsNumber > 0)
                {
                    GameObject bullet = Instantiate(bulletPrefab, shotPosition.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody>().velocity = transform.forward * weaponManager.bulletSpeed;
                    bullet.transform.parent = gameObject.transform;
                    timer = Time.time + 1f / weaponManager.shootingRate;
                    weaponManager.bulletsNumber--;
                    Destroy(bullet, weaponManager.shootingRange);
                }
                else
                {
                    StartCoroutine(Reload(weaponManager));
                }
            }
        }
    }

    private void ChangeWeaponInformation(int index)
    {
        Instantiate(weapons[index], transform);
        WeaponManager weaponManager = weapons[index].GetComponent<WeaponManager>();
        if (weaponManager != null)
        {
            damage = weaponManager.damage;
        }
        if (transform.childCount > 2)
            Destroy(transform.GetChild(1).gameObject);
    }

    private IEnumerator Reload(WeaponManager weaponManager)
    {
        yield return new WaitForSeconds(weaponManager.reloadingSpeed);
        weaponManager.bulletsNumber = weaponManager.maxBulletsNumber;
    }
}
