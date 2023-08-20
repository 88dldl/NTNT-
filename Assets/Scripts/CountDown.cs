using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDown : MonoBehaviour
{
    [SerializeField] float setTime = 100.0f;
    [SerializeField] Text countdownText;

    public int starcount;
    // public GameObject ending;

    // Start is called before the first frame update
    void Start()
    {
        // ending.SetActive(false);
        countdownText.text = setTime.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime>0){
            setTime-=Time.deltaTime;
        }       
        countdownText.text = Mathf.Round(setTime).ToString();
        Ending();
    }
    void Ending(){
        int count=GameObject.FindGameObjectsWithTag("Enemy").Length;
        int health = GameObject.Find("Capsule").GetComponent<PlayerHealth>().CurrentHealth;
        //성공
        if(setTime>0 && health>0){
            if(count==0){
                SceneManager.LoadScene(6);
            }
        }
        //실패
        else if(setTime<=0 || health<=0){
            SceneManager.LoadScene(8);
        }
    }
}
