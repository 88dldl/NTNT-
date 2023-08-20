using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageChoice{stageone,stagetwo, stagethree}

public class ChoiceBtn : MonoBehaviour
{
    private StageChoice stagechoice;
    public StageChoice current;
    public GameObject ChoiceOne;
    public GameObject ChoiceOtherPopUp;
    public GameObject Preparing;

    public void Start(){
        ChoiceOtherPopUp.SetActive(false);
        Preparing.SetActive(false);
    }
    public void Update(){

    }
    public void Choice(){
        switch(current){
            case StageChoice.stageone:
                SceneLoad.LoadSceneHandle("FinalGame",0);
                break;
            case StageChoice.stagetwo:
                if(transform.GetChild(0).gameObject.activeSelf==true){
                    ChoiceOtherPopUp.SetActive(true);
                }
                else{
                    Preparing.SetActive(true); // 일단 준비중 띄움
                // else if(transform.GetChild(1).gameObject.activeSelf==true || transform.GetChild(1).gameObject.activeSelf==false){
                    // SceneLoad.LoadSceneHandle("씬 제목 적으세요",0);
                }
                break;
            case StageChoice.stagethree:
                if(transform.GetChild(0).gameObject.activeSelf==true){
                    ChoiceOtherPopUp.SetActive(true);
                }
                else{
                    //씬 로드
                }
            break;
        }
        // if(ChoiceOne){ // 조건수정필요함
        //     SceneLoad.LoadSceneHandle("Demo_Scene",0); // 게임 시작, 0(새로시작)
        // }
        // else{
        //     ChoiceOtherPopUp.SetActive(true);
        // }
    }
    public void deleteP(){
        ChoiceOtherPopUp.SetActive(false);
    }
}
