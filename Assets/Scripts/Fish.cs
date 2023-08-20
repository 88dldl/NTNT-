using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject fishPosition; // 무기 발사 위치 지정
    public GameObject fishfactory; // 무기 오브젝트
    public float throwPower = 15f; // 무기 던지는 힘

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 버튼으로 발사
        if(Input.GetMouseButtonDown(0) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject fish = Instantiate(fishfactory); // 생성
            fish.transform.position = fishPosition.transform.position; // 위치 동일하게 설정
            Rigidbody rb = fish.GetComponent<Rigidbody>(); // 중력 설정

            //카메라 정면 방향으로 던짐 (방향 * 힘)
            rb.AddForce(Camera.main.transform.forward * throwPower , ForceMode.Impulse);
        }
    }

    // void ThrowFish()
    // {
    //     currentFish.transform.parent = null; // 무기와 fishPosition의 부모 관계 해제

    //     Rigidbody rb = currentFish.GetComponent<Rigidbody>(); // 중력 설정
    //     if (rb != null)
    //     {
    //         rb.isKinematic = false; // 무기에 중력 적용
    //         rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse); // 카메라 정면 방향으로 던짐 (방향 * 힘)
    //     }

    //     currentFish = null; // 무기 해제
    // }
}
