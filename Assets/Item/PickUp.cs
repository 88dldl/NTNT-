using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    
    private void OnTriggerEnter(Collider collider){
        if(collider.tag.Equals("Player")){
            Inventory inven = collider.GetComponent<Inventory>();
            for(int i=0;i<inven.slots.Count;i++){
                if(inven.slots[i].isEmpty){
                    Instantiate(slotItem,inven.slots[i].slotObj.transform,false);
                    inven.slots[i].isEmpty =false;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
