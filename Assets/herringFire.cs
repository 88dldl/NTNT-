using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herringFire : MonoBehaviour
{
    public PlayerFire playerFire;

    // Start is called before the first frame update
    void Start()
    {
        playerFire = GameObject.Find("Main").transform.Find("Fish").gameObject.GetComponent<PlayerFire>();
        //Debug.Log(playerFire.name);
    }

    // Update is called once per frame
    void Update()
    {
        // 기능추가 
       if(Input.inputString==(transform.parent.GetComponent<Slot>().num+1).ToString()){
            playerFire.ThrowFish();
            Destroy(gameObject);
       } 
    }
}
