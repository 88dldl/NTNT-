using UnityEngine;

public class FishDamage : MonoBehaviour
{
    public float damageRadius = 50f; // 데미지 반경
    public int damageAmount = 15; // 입힐 데미지 양

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 땅과 충돌한 경우
        {
            // 주변의 Collider 가져오기
            Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy")) // 적과 충돌한 경우
                {
                    // 적의 체력 감소시키기
                    newenemy enemy = collider.GetComponent<newenemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damageAmount); // damageAmount 값을 전달
                    }
                }
            }

            Destroy(gameObject); // 물고기 제거
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 데미지 반경을 시각적으로 표시하기 위한 Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
