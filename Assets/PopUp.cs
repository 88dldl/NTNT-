using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public GameObject CanvasPause;
    public GameObject BtnPause;
    public GameObject BtnReStart;
    public GameObject BtnContinue;
    public GameObject BtnGameEnd;
    public GameObject CanvasStart;

    public string thisScene;
    //멈춰
    public void Pause(){
        thisScene=SceneManager.GetActiveScene().name;
        Time.timeScale=0f;
        // CanvasPause.SetActive(true);
        // CanvasStart.SetActive(false);
    }

    //재시작
    public void Restart(){
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    //이어서 시작
    public void Continue(){
        // CanvasPause.SetActive(false);
        // CanvasStart.SetActive(true);
        Time.timeScale=1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    //게임종료
    public void GameEnd(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
        #else   
            Application.Quit();
        #endif
    }
}
