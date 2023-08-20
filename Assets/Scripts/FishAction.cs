using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAction : MonoBehaviour
{
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision) {
        {
            //이펙트 프리팹 생성
            GameObject eff = Instantiate(bombEffect);
            //이펙트 프리팹 위치 설정
            eff.transform.position = transform.position;
            Destroy(gameObject); // 제거
        }
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
