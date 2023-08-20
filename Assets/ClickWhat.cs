using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    public GameObject clickObject;
    public void ClickBtn(){
        clickObject = EventSystem.current.currentSelectedGameObject;
        PlayerPrefs.SetString("name",clickObject.name);
    }
}
