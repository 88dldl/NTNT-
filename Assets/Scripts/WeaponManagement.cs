// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    public float switchDelay =1f;
    public GameObject[] weapons;

    private int index = 0;
    private bool isSwitching = false;

    // Start is called before the first frame update
    private void Start()
    {
        InitializeWeapon();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)&& !isSwitching){
           SwitchWeapon(0);
        }
        // if(Input.GetKeyDown(KeyCode.Alpha2)&&!isSwitching ){
            // SwitchWeapon(1);
        // }
        
    }
    private void InitializeWeapon(){
        for(int i=0;i<weapons.Length;i++){
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
        index=0;
    }
    private void SwitchWeapon(int newIndex){
        isSwitching=true;
        for(int i=0;i<weapons.Length;i++){
            weapons[i].SetActive(false);
        }
        weapons[newIndex].SetActive(true);
        isSwitching=false;
    }
}
