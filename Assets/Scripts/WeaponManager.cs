using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Properties")]
    public GameObject weapon;
    public Sprite weaponSprite;
    public int damage;
    public int maxBulletsNumber;
    public int bulletsNumber;
    public float bulletSpeed;
    public float shootingRange;
    public float shootingRate;
    public float reloadingSpeed;

    private void Awake()
    {
        bulletsNumber = maxBulletsNumber;
    }
}
