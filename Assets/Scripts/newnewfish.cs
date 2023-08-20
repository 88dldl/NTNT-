using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newnewfish : MonoBehaviour
{
    public GameObject fishPosition; // 무기 발사 위치 지정
    public GameObject fishfactory; // 무기 오브젝트
    public GameObject explosionEffect; // 폭발 이펙트 프리팹
    public float throwPower = 15f; // 무기 던지는 힘
    public float throwDuration = 0.5f; // 던지는 시간
    public float explosionDelay = 2f; // 폭발 이펙트 지속 시간

    private bool isThrown = false; // 물고기가 던져졌는지 여부
    private GameObject currentFish; // 현재 생성된 물고기 오브젝트

    void Update()
    {
        // 2번을 누르면 물고기를 생성하여 가만히 있게 함
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isThrown)
        {
            CreateFish();
        }

        // 마우스 왼쪽 버튼을 누르면 물고기를 던지고 일정 시간 후에 폭발
        if (isThrown && Input.GetMouseButtonDown(0))
        {
            ThrowFish();
            StartCoroutine(ExplodeFishDelayed());
        }
    }

    private void CreateFish()
    {
        isThrown = true;
        
        if (currentFish != null)
            Destroy(currentFish);

        // 물고기 생성
        currentFish = Instantiate(fishfactory);
        currentFish.transform.position = fishPosition.transform.position;
    }

    private void ThrowFish()
    {
        if (currentFish == null)
            return;

        // 카메라 정면 방향으로 일정한 속도로 이동
        Vector3 throwDirection = Camera.main.transform.forward;
        Vector3 throwVelocity = throwDirection * throwPower;

        StartCoroutine(MoveFish(throwVelocity));
    }

    private IEnumerator MoveFish(Vector3 velocity)
    {
        float elapsedTime = 0f;
        while (elapsedTime < throwDuration)
        {
            currentFish.transform.Translate(velocity * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ExplodeFishDelayed()
    {
        yield return new WaitForSeconds(explosionDelay);

        // 폭발 이펙트 생성
        GameObject explosion = Instantiate(explosionEffect);
        explosion.transform.position = currentFish.transform.position;

        Destroy(explosion, 2f); // 폭발 이펙트를 2초 후에 제거

        Destroy(currentFish); // 물고기 제거
        currentFish = null;

        isThrown = false; // 물고기 던지기 상태 초기화
    }
}
