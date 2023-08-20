using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public GameObject itemPrefab; // 아이템 프리팹
    public GameObject explodeEffectPrefab; // 이펙트
    private int hitsRemaining = 3; // 쓰레기통을 공격해야 하는 횟수
    public AudioSource itemSound;

    public void AttackTrashCan(Collision collision)
    {
        if (hitsRemaining > 0)
        {

            hitsRemaining--;
 
            if (hitsRemaining == 0)
            {
                // 아이템 생성 위치 = 쓰레기통의 위치 약간 랜덤 (주변에 떨어지게 뭔지 알지)
                Vector3 spawnPosition = GetRandomPositionAroundTrashCan(transform.position, 3.0f);
                spawnPosition.y += 0.3f;

                // 아이템 생성
                Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
                itemSound.Play();

                // 이펙트
                if (explodeEffectPrefab != null)
                {
                    GameObject explosion = Instantiate(explodeEffectPrefab, spawnPosition, Quaternion.identity);
                    Destroy(explosion, 1f);
                }
            }
        }
    }
    private Vector3 GetRandomPositionAroundTrashCan(Vector3 center, float radius) // 쓰레기통 주변 랜덤 위치 생성하게 하는
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * radius;
        return center + new Vector3(randomCircle.x, 0f, randomCircle.y);
    }
}
