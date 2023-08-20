using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatChur : MonoBehaviour
{
    public GameObject slotItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            PickUpItem player=col.GetComponent<PickUpItem>();
            for(int i=0;i<player.slots.Count;i++){
                if(player.slots[i].isEmpty){
                    //생성할 오브젝트 , 위치, flase
                    Instantiate(slotItem,player.slots[i].slotObj.transform,false);
                    player.slots[i].isEmpty=false;
                    Destroy(gameObject);
                    break;
                }
            }
            // player.itemCount++;
            
        }
    }
}
