using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readymusic : MonoBehaviour
{
    public AudioSource Ready;
    // Start is called before the first frame update
    void Start()
    {
        var obj = FindObjectsOfType<Readymusic>();
        // DontDestroyOnLoad(gameObject);
        if(obj.Length==1){
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
        Ready.Play();
        DontDestroyOnLoad(Ready);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
