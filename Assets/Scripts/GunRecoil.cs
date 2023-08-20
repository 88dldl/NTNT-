using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public float maxRecoilDistance = 0.1f; // 최대 반동 거리
    public float recoilSpeed = 5.0f;      // 반동 속도

    private Vector3 originalPosition;
    private Vector3 recoilPosition;
    private bool isRecoiling = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            Recoil();
        }

        if (isRecoiling)
        {
            // 부드러운 반동 효과를 위해 Lerp 사용
            transform.localPosition = Vector3.Lerp(transform.localPosition, recoilPosition, Time.deltaTime * recoilSpeed);

            // 반동 위치와 원래 위치 사이의 거리가 일정 값 미만이면 반동 효과 종료
            if (Vector3.Distance(transform.localPosition, recoilPosition) < 0.001f)
            {
                isRecoiling = false;
            }
        }
        else
        {
            // 반동 효과가 종료되었을 때 원래 위치로 돌아오기 위한 보간
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * recoilSpeed);
        }
    }

    void Recoil()
    {
        // 반동 위치 계산
        recoilPosition = originalPosition - transform.forward * maxRecoilDistance;
        isRecoiling = true;
    }
}
