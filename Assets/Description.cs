using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Description : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public Transform buttonScale;
    public GameObject back;
    Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale=buttonScale.localScale;
        if(first.activeSelf==true){
            back.SetActive(false);
        }
    }

    public void PressBtn(){
        if(first.activeSelf==true){
            first.SetActive(false);
            second.SetActive(true);
            back.SetActive(true);
            // Debug.Log("된다");
        }
        else if(second.activeSelf==true){
            second.SetActive(false);
            third.SetActive(true);
        }
        else if(third.activeSelf==true){
            SceneManager.LoadScene(0);
        }
    }
    public void backBtn(){
        if(second.activeSelf==true){
            second.SetActive(false);
            first.SetActive(true);
            back.SetActive(false);
        }
        else if(third.activeSelf==true){
            third.SetActive(false);
            second.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {        
    }
    public void OnPointerEnter(PointerEventData eventData){
        buttonScale.localScale = defaultScale*1.2f;
    }

    public void OnPointerExit(PointerEventData eventData){
        buttonScale.localScale=defaultScale;
    }
}
