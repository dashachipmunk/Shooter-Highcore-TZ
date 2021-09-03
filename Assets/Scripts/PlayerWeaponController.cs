using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponController : MonoBehaviour
{
    private float timer;
    private int weaponIndex;
    private int damage;

    [Header("References")]
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform shotPosition;

    [Header("Canvas References")]
    [SerializeField]
    private Image weaponImage;
    [SerializeField]
    private Text bulletsNumberText;

    public int Damage { get => damage; set => damage = value; }

    private void Awake()
    {
        weaponIndex = 0;
        ChangeWeaponInformation(weaponIndex);
    }

    private void Update()
    {
        SwitchWeapon();
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
                    bulletsNumberText.text = weaponManager.bulletsNumber.ToString();
                }
                else
                {
                    StartCoroutine(Reload(weaponManager));
                }
            }
        }
    }

    private void SwitchWeapon()
    {
        int previousWeaponIndex = weaponIndex;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weaponIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            weaponIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            weaponIndex = 2;
        if (previousWeaponIndex != weaponIndex)
            ChangeWeaponInformation(weaponIndex);
    }

    private void ChangeWeaponInformation(int index)
    {
        Instantiate(weapons[index], transform);
        WeaponManager weaponManager = weapons[index].GetComponent<WeaponManager>();
        if (weaponManager != null)
        {
            damage = weaponManager.damage;
            weaponImage.sprite = weaponManager.weaponSprite;
            bulletsNumberText.text = weaponManager.bulletsNumber.ToString();
        }
        if (transform.childCount > 2)
            Destroy(transform.GetChild(1).gameObject);
    }

    private IEnumerator Reload(WeaponManager weaponManager)
    {
        yield return new WaitForSeconds(weaponManager.reloadingSpeed);
        weaponManager.bulletsNumber = weaponManager.maxBulletsNumber;
        bulletsNumberText.text = weaponManager.bulletsNumber.ToString();
    }
}
