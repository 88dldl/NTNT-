using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyObject : MonoBehaviour
{    
    public bool isLock=false;
    public bool isClear=false;
    public GameObject clickStage;
    public GameObject now;
    public GameObject next;
    int count;
    void Start()
    {
        var obj = FindObjectsOfType<DontDestroyObject>();
        // DontDestroyOnLoad(gameObject);
        if(obj.Length==1){
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        now = GameObject.Find(PlayerPrefs.GetString("name"));
        count= int.Parse(now.name.Substring(12,1))+1;

        next=GameObject.Find(PlayerPrefs.GetString("name").Substring(0,12)+count.ToString());
        Debug.Log(next.name);
        
        if(SceneManager.GetActiveScene().name=="ChoiceStage"){
            // clickStage = GameObject.Find("CanvasBtn").GetComponent<ClickWhat>().clickObject;
            // if(isLock){
            //     now.transform.GetChild(0).gameObject.SetActive(true);
            // }
            // else 
            if(isClear){
                now.transform.GetChild(0).gameObject.SetActive(false);
                now.transform.GetChild(1).gameObject.SetActive(true);
                next.transform.GetChild(0).gameObject.SetActive(false);
                isClear=false;
            }        
        }
    }

}
