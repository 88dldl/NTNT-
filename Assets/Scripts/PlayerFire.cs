using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject fishPrefab; // 물고기 프리팹을 할당할 변수
    public Transform throwPoint; // 물고기를 던질 위치를 할당할 변수
    public GameObject explosionObject; // 폭발 오브젝트를 할당할 변수
    public float throwPower = 50f; // 물고기를 던질 힘의 세기
    public bool isFire=false;
    public GameObject thrownFish; // 물고기 위치 넘겨주기 위한 임시 변수랄까
    public GameObject moveFish;
    void Update()
    {
        if (isFire) // 마우스 오른쪽 버튼을 눌렀을 때
        {
            ThrowFish(); // 물고기 던지는 함수 호출
        }
    }

    public void ThrowFish()
    {
        // 물고기 던지는 로직
        GameObject thrownFish = Instantiate(fishPrefab, throwPoint.position, throwPoint.rotation);
        moveFish = thrownFish;
        Rigidbody fishRigidbody = thrownFish.GetComponent<Rigidbody>();
        fishRigidbody.AddForce(throwPoint.forward * throwPower, ForceMode.Impulse);        // 물고기에 폭발 이벤트 추가
        //FishExplosion fishExplosion = thrownFish.AddComponent<FishExplosion>();
        //fishExplosion.explosionObject = explosionObject;


        FishCollisionHandler collisionHandler = thrownFish.AddComponent<FishCollisionHandler>();
        collisionHandler.explosionObject = explosionObject;

        // 물고기 위치 전달 (newenemy로)
        newenemy enemyScript = FindObjectOfType<newenemy>();
        enemyScript.ReceiveFish(thrownFish);

        WhiteCat enemyScript2 = FindObjectOfType<WhiteCat>();
        //enemyScript2.ReceiveFish(thrownFish);

        finalenemy enemyScript3 = FindObjectOfType<finalenemy>();
        // enemyScript3.ReceiveFish(thrownFish);

        Destroy(thrownFish, 5f);
        enemyScript.isBeingPulled=false;
    }

}
public class FishCollisionHandler : MonoBehaviour
{
    public GameObject explosionObject;

    private bool hasCollided = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("Ground"))
        {
            hasCollided = true;
            // 물고기가 땅과 충돌했을 때 이펙트 (땅에 다 ground 태그해야돼)
            if (explosionObject != null)
            {
                //Instantiate(explosionObject, transform.position, Quaternion.identity);
                GameObject explosion = Instantiate(explosionObject, transform.position, Quaternion.identity);
                Destroy(explosion, 5f);
            }
        }
    }
}