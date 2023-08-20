using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory inventory;
    //몇번슬롯인지 확인
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        inventory=GameObject.FindWithTag("Player").GetComponent<Inventory>();
        // 슬롯의 번호를 숫자로 사용 가능하게 
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_")+1));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount<=0){
            inventory.slots[num].isEmpty=true;
        }
    }
}
