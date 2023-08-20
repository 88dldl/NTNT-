using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newfish : MonoBehaviour
{
    public GameObject fishPosition; // 무기 발사 위치 지정
    public GameObject fishfactory; // 무기 오브젝트
    public GameObject explosionEffect; // 폭발 이펙트 오브젝트
    public float throwPower = 50f; // 무기 던지는 힘
    public float explosionDelay = 30f; // 폭발까지의 지연 시간

    private bool isThrown = false; // 물고기가 던져졌는지 여부를 확인하기 위한 변수

    void Update()
    {
        // 2번을 누르면 물고기를 던짐
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isThrown = true; // 물고기를 던짐
            ThrowFish();
        }

        // 마우스 왼쪽 버튼을 누르면 폭발
        if (isThrown && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ExplodeFishDelayed());
        }
    }

    private void ThrowFish()
    {
        GameObject fish = Instantiate(fishfactory); // 생성
        fish.transform.position = fishPosition.transform.position; // 위치 동일하게 설정
        Rigidbody rb = fish.GetComponent<Rigidbody>(); // 중력 설정

        // 카메라 정면 방향으로 던짐 (방향 * 힘)
        rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
    }

    private IEnumerator ExplodeFishDelayed()
    {
        yield return new WaitForSeconds(explosionDelay);

        // 폭발 이펙트 생성
        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = transform.position;

        Destroy(explosion, 2f); // 폭발 이펙트를 2초 후에 제거

        Destroy(gameObject); // 물고기 제거
    }
}
