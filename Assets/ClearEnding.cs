using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEnding : MonoBehaviour
{
    public GameObject clearGame;
    void Start()
    {
        // GameObject.Find("GameObject").GetComponent<DontDestroyObject>().isLock=false;
        GameObject.Find("DD").GetComponent<DontDestroyObject>().isClear=true;
        // GameObject.Find("DD").GetComponent<DontDestroyObject>().isLock=false;
    }

}
