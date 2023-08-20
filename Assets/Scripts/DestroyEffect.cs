using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    //효과 제거 시간
    public float destroyTime = 1.5f;
    //경과 시간측정
    float currentTime = 0;

    void Start()
    {
    }

    void Update()
    {
        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}
