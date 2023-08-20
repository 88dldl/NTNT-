using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionBack : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject first;
    public GameObject second;
    public GameObject third;

    public Transform buttonScale;
    Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale=buttonScale.localScale;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void backButton(){
        if(second.activeSelf==true){
            second.SetActive(false);
            first.SetActive(true);
            // Debug.Log("1");
        }
        else if(third.activeSelf==true){
            third.SetActive(false);
            second.SetActive(true);

        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        buttonScale.localScale=defaultScale*1.2f;
    }
    public void OnPointerExit(PointerEventData eventData){
        buttonScale.localScale=defaultScale;
    }
}
