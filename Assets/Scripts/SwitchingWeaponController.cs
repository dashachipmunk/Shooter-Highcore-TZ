using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingWeaponController : MonoBehaviour
{
    private int selectedWeaponIndex;

    [Header("References")]
    [SerializeField]
    private Image weaponImage;
    [SerializeField]
    private Text bulletsNumber;
    [SerializeField]
    private WeaponController[] weaponControllers;
    
    private void Awake()
    {
        selectedWeaponIndex = 0;
        weaponImage.sprite = weaponControllers[0].weaponSprite;
        bulletsNumber.text = weaponControllers[0].maxBulletsNumber.ToString();
    }

    private void Update()
    {
        SwitchWeapon();
    }

    private void SwitchWeapon()
    {
        int previousWeaponIndex = selectedWeaponIndex;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeaponIndex = 0;
            weaponImage.sprite = weaponControllers[0].weaponSprite;
            bulletsNumber.text = weaponControllers[0].maxBulletsNumber.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeaponIndex = 1;
            weaponImage.sprite = weaponControllers[1].weaponSprite;
            bulletsNumber.text = weaponControllers[1].maxBulletsNumber.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeaponIndex = 2;
            weaponImage.sprite = weaponControllers[2].weaponSprite;
            bulletsNumber.text = weaponControllers[2].maxBulletsNumber.ToString();

        }
        if (previousWeaponIndex != selectedWeaponIndex)
        {
            SelectNewWeapon();
        }
    }

    private void SelectNewWeapon()
    {
        int index = 0;
        foreach (Transform weapon in transform)
        {
            if (index == selectedWeaponIndex)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            index++;
        }
    }
}
