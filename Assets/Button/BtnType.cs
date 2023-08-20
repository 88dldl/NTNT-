using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup ClearEndingGroup;
    public CanvasGroup FailEndingGroup;
    public CanvasGroup DescriptionGroup;
    public CanvasGroup LoadingGroup;
    public GameObject AfterLoad;

    public GameObject pause;
    public GameObject clear;
    public GameObject control;
    public GameObject setting;

    public void Start(){
        defaultScale = buttonScale.localScale;
        pause.SetActive(false);
        control.SetActive(false);
        setting.SetActive(false);
    }

    bool isSound;
    //버튼 클릭 동작
    public void OnBtnClick(){
        switch (currentType)
        {
            case BTNType.Start:
                Time.timeScale=1f;
                SceneManager.LoadScene(3); // 맵 선택으로 이동 
                // SceneLoad.LoadSceneHandle("Start",0);
                // ChoiceBtn.Choice();
                break;
            case BTNType.Continue:
                SceneLoad.LoadSceneHandle("Start",1);
                break;   
            case BTNType.Option:
                pause.SetActive(true); // 창띄우기 
                Time.timeScale=0f;
                break;
            case BTNType.Back:
                // Time.timeScale=1f;
                pause.SetActive(false); // 원래 화면으로 돌아가기
                Time.timeScale=1f; // 멈춤 없앰 
                break;
            case BTNType.Quit :
                // gameObject.transform.GetComponent<PopUp>().Restart();
                Application.Quit();
                Debug.Log("앱종료");
                break;
            case BTNType.Home:
                Time.timeScale=1f;
                SceneManager.LoadScene(0); //main화면 띄워 
                // Debug.Log("Go to Home");
                break;
            case BTNType.Again:
                Time.timeScale=1f;
                SceneLoad.LoadSceneHandle("FinalGame",0);
                break;
            case BTNType.Control :
                Time.timeScale=0f;
                control.SetActive(true);
                break;
            case BTNType.Setting:
                setting.SetActive(true);
                break;
            case BTNType.Description:
                SceneManager.LoadScene(7);
                break;
            case BTNType.BackToHome:
                SceneManager.LoadScene(0);
                break;
        }
    }
    public void CanvasGroupOn(CanvasGroup cg){
        cg.alpha=1;
        cg.interactable = true;
        cg.blocksRaycasts=true;
    }
    public void CanvasGroupOff(CanvasGroup cg){
        cg.alpha =0;
        cg.interactable = false;
        cg.blocksRaycasts=false;

    }
    // 마우스가 버튼 위에 있을때 크기 커짐
    public void OnPointerEnter(PointerEventData eventData){
        buttonScale.localScale =  defaultScale*1.2f;
    }
    public void OnPointerExit(PointerEventData eventData){
        buttonScale.localScale = defaultScale;
    }
    // IEnumerator AfterLoading(){
    //     yield return null;
    //     // if(AfterLoad.GetComponent<SceneLoad>().LoadingEnd==1){
    //     //     Debug.Log("that's all");
    //     //     // AfterLoad.GetComponent<SceneLoad>().LoadingEnd=0;
    //     // }
    // }
}
