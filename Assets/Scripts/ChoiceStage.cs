using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonType{b1,b2,b3}

public class ChoiceStage : MonoBehaviour
{
    public ButtonType buttonType;

    
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Choice());
    }

    public void OnBtnClick(){
        switch(buttonType){
            case ButtonType.b1:
                SceneManager.LoadScene(1);
                break;
        }
    }
    // IEnumerator Choice(){
        // yield return null;
    // }

}
