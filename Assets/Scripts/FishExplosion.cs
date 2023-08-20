using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishExplosion : MonoBehaviour
{
    public GameObject explosionObject; // 폭발 오브젝트를 할당할 변수

    public void OnCollisionEnter(Collision collision)
    {
        // 충돌한 대상이 바닥, 지형인지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 폭발 오브젝트를 활성화하고 위치를 설정한 후, 일정 시간 후에 비활성화
            StartCoroutine(ActivateExplosionObject(transform.position));

            // 물고기 제거
            Destroy(gameObject);
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // 충돌한 대상이 Enemy인지 확인
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            // 폭발 오브젝트를 활성화하고 위치를 설정한 후, 일정 시간 후에 비활성화
            StartCoroutine(ActivateExplosionObject(transform.position));

            // 물고기 제거
            Destroy(gameObject);
        }
    }

    public IEnumerator ActivateExplosionObject(Vector3 position)
    {
        // 폭발 오브젝트를 생성하고 위치를 설정한 후, 일정 시간 후에 비활성화
        GameObject explosion = Instantiate(explosionObject, position, Quaternion.identity);

        yield return new WaitForSeconds(explosion.GetComponent<ParticleSystem>().main.duration);

        // 폭발 오브젝트 제거
        Destroy(explosion);
    }
}
