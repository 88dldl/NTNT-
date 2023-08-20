using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(control.activeSelf==true){
                Time.timeScale=1f;
                control.SetActive(false);
            }
            else{
                Time.timeScale=0f;
                control.SetActive(true);
            }
        }
    }
}
