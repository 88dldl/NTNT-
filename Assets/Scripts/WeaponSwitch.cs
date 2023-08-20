using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons; // 무기 프리팹들을 저장할 배열
    private int currentWeaponIndex = 0; // 현재 선택된 무기의 인덱스

    private void Start()
    {
        // 일단 모든 무기 비활성화!
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        //ActivateWeapon(0);
        //근데 첫 화면에 바로 뜨게는 못 함 수정해야됨
        //ActivateWeapon(currentWeaponIndex); //둘 중 하나 쓰기, 첫 번째 무기를 활성화
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 키보드 숫자 1을 누르면 첫 번째 무기로 교체
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 키보드 숫자 2를 누르면 두 번째 무기로 교체
        {
            SwitchWeapon(1);
        }
    }

    private void ActivateWeapon(int weaponIndex)
    {
        // 현재 무기를 비활성화
        DeactivateCurrentWeapon();

        // 선택한 인덱스의 무기를 활성화
        weapons[weaponIndex].SetActive(true);
    }

    private void DeactivateCurrentWeapon()
    {
        // 현재 무기를 비활성화
        //weapons[currentWeaponIndex].SetActive(false);
        if (weapons[currentWeaponIndex] != null && weapons[currentWeaponIndex].activeSelf)
        {
            weapons[currentWeaponIndex].SetActive(false);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weapons.Length)
        {
            if (currentWeaponIndex != weaponIndex )//if만 새로 추가
            {
                DeactivateCurrentWeapon();
                currentWeaponIndex = weaponIndex;
                ActivateWeapon(currentWeaponIndex);
            }
            else if(!weapons[currentWeaponIndex].activeSelf)
            {
                ActivateWeapon(currentWeaponIndex);
            }
        }
    }
}
