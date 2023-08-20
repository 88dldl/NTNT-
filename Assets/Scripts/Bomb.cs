using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //public GameObject bombEffect;
    //충돌 처리 함수
    private void OnCollisionEnter(Collision collision)
    {
        //이펙트 프리팹 생성
        //GameObject eff = Instantiate(bombEffect);
        //이펙트 위치
        //eff.transform.position = transform.position;
        //자기 오브젝트 제거
        //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
