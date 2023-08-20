using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    private int count = 0;

    public AudioSource playersound;
    public AudioSource hitsound;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(CurrentHealth);
        // if(Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     CurrentHealth -= 5;
        // } 1번 키 먹는지 테스트 코드
        HealthBar.value = (float)CurrentHealth / (float)MaxHealth;
        //체력 슬라이더의 값 넣어주기
        if(CurrentHealth<100){
        if(count!=1000){
            count+=1;
        }        
        else{
            CurrentHealth+=1;
            count=0;
        }}
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            // 플레이어 사망 처리 (게임 오버 화면 or 게임 재시작
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            TakeDamage(5);
            hitsound.Play();
        }
        else if(collision.transform.CompareTag("Enemybullet")){
            TakeDamage(7);
            playersound.Play();
        }
    }
}
