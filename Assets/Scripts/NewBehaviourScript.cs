using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject fishPrefab; // 물고기 프리팹을 할당할 변수
    public Transform throwPoint; // 물고기를 던질 위치를 할당할 변수
    public GameObject explosionObject; // 폭발 오브젝트를 할당할 변수
    public float throwForce = 10f; // 물고기를 던질 힘의 세기

    private bool isFishThrown; // 물고기가 이미 던져졌는지 여부를 저장하는 변수

    void Update()
    {
        if (!isFishThrown && Input.GetMouseButtonDown(0)) // 물고기가 던져지지 않은 상태에서 마우스 왼쪽을 눌렀을 때
        {
            ThrowFish(); // 물고기 던지는 함수 호출
        }
    }

    void ThrowFish()
    {
        // 물고기 던지는 로직
        GameObject thrownFish = Instantiate(fishPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody fishRigidbody = thrownFish.GetComponent<Rigidbody>();
        fishRigidbody.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

        // 물고기에 폭발 이벤트 추가
        FishExplosion fishExplosion = thrownFish.AddComponent<FishExplosion>();
        fishExplosion.explosionObject = explosionObject;

        isFishThrown = true; // 물고기가 던져졌음을 표시
    }
    //폭발이 안먹어서 임시 제거
    // void ThrowFish()
    // {
    //     // 물고기 던지는 로직
    //     GameObject thrownFish = Instantiate(fishPrefab, throwPoint.position, throwPoint.rotation);
    //     Rigidbody fishRigidbody = thrownFish.GetComponent<Rigidbody>();
    //     fishRigidbody.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

    //     // 폭발 오브젝트를 활성화하고 위치를 설정한 후, 일정 시간 후에 비활성화
    //     StartCoroutine(ActivateExplosionObject(thrownFish.transform.position));

    //     isFishThrown = true; // 물고기가 던져졌음을 표시
    // }

    //폭발이 안먹어서 임시 제거
    // IEnumerator ActivateExplosionObject(Vector3 position)
    // {
    //     // 폭발 오브젝트를 생성하고 위치를 설정한 후, 일정 시간 후에 비활성화
    //     GameObject explosion = Instantiate(explosionObject, position, Quaternion.identity);
    //     ExplosionPosition explosionPosition = explosion.GetComponent<ExplosionPosition>();
    //     explosionPosition.SetTargetTransform(transform);

    //     // 일정 시간 후에 폭발 오브젝트 비활성화
    //     yield return new WaitForSeconds(explosion.GetComponent<ParticleSystem>().main.duration);
    //     explosion.SetActive(false);

    //     // 폭발 오브젝트 제거
    //     Destroy(explosion);
    // }
}
