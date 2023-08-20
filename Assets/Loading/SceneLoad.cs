using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using TMPro;
public class SceneLoad : MonoBehaviour
{
    public Slider progerssbar;
    public Text loadtext;
    public static string loadScene;
    public static int loadType;
    public int LoadingEnd;

    private void Start(){
        StartCoroutine(LoadScene());
    }
    public static void LoadSceneHandle(string _name, int _loadType){
        loadScene = _name;
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }
    IEnumerator LoadScene(){
        yield return null;
        // progerssbar.value=0f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        operation.allowSceneActivation=false;

        //슬라이드 값 증가 
        while(!operation.isDone){
            yield return null;
            if(loadType==0){
                Debug.Log("새게임");
            }
            else if(loadType==1){
                Debug.Log("헌게임");
            }
            if(progerssbar.value<0.9f){
                progerssbar.value=Mathf.MoveTowards(progerssbar.value,0.9f,Time.deltaTime);
                
            }
            else if(progerssbar.value>=0.9f){
                progerssbar.value = Mathf.MoveTowards(progerssbar.value,1f,Time.deltaTime);
            }
            if(progerssbar.value>=1f){
                loadtext.text="Press the Space";
                // LoadingEnd=1;
            }

            if(Input.GetKeyDown(KeyCode.Space)&&progerssbar.value>=1f&& operation.progress>=0.9f){
                operation.allowSceneActivation=true;
                SceneManager.LoadScene(2);
             }
        }
    }
}
