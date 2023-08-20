using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // 키보드 입력값이 아이템이 속해있는 슬롯의 번호와 일치할떄 사용 
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.inputString ==(transform.parent.GetComponent<Slot>().num+1).ToString()){
            if(playerHealth.CurrentHealth+20>100){
                playerHealth.CurrentHealth=100;
            }
            else{
            playerHealth.CurrentHealth+=20;}
            Destroy(gameObject);
        }
    }
}
