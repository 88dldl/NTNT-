using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot =4;
    public int itemCount=0;
    public GameObject slotPrefab;

    // Start is called before the first frame update
    void Start()
    { 
      GameObject slotPanel = GameObject.Find("Panel");
      for(int i=0;i<maxSlot;i++){
        //slot prefab생성
        GameObject go =Instantiate(slotPrefab,slotPanel.transform,false);
        go.name="Slot_"+i;
        SlotData slot = new SlotData();
        slot.isEmpty=true;
        slot.slotObj=go;
        slots.Add(slot);
      }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
