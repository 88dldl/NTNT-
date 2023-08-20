using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // 무기 프리팹들을 저장할 배열

    private void Start()
    {
        // 무기 프리팹들을 동적으로 할당
        weapons = new GameObject[3]; // 예시로 크기 3의 배열을 할당

        // 무기 프리팹 인스턴스 생성 후 배열에 할당
        weapons[0] = Instantiate(Resources.Load<GameObject>("PistolPrefab"));

        // 필요한 경우 프리팹 인스턴스의 초기 설정을 수행
        // 예: 위치, 회전, 부모 설정 등
    }
}
