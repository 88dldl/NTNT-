using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public Image Scratch;
    // Start is called before the first frame update
    void Start()
    {
        Scratch.color = Color.clear;        
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(ShowScratch()); 
    }

    IEnumerator ShowScratch(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Scratch.color = new Color(1,0,0,UnityEngine.Random.Range(0.5f,0.6f));
            yield return new WaitForSeconds(0.1f);
            
            Scratch.color = Color.clear;
        }
    }
}
