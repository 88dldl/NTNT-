using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newenemy : MonoBehaviour
{
    private Animation anim;

    public GameObject WayPoint1;
    public GameObject WayPoint2;
    public GameObject Player;

    public float MoveSpeed = 2.0f;
    public bool isArrived = false;
    public bool isCombat = false;

    public int Delay;
    public EnemyGun EG;

    public int Health = 15;

    private GameObject fishObject; // 물고기 오브젝트를 저장할 변수 (player fire에서 받아옴)

    public bool isBeingPulled = false; // 끌려가는 중인지
    private float pullSpeed = 5f; // 끌어당기는 속도
    private float pullDistance = 1.5f; // 물고기와 적 사이 거리
    private float pullHeight = 5f; // 적이 물고기보다 높이 떠 있는 거리
    private float minHeight = 0f; // 적의 최소 높이
    private float maxHeight = 0.2f; // 적의 최대 높이
    public float offsetRange = 0.1f; // 랜덤하게 위치하려고 씀
    public bool isCombatEnabled = true; // 적이 플레이어를 공격할 수 있는지 (true면 공격 가능, false면 공격 불가능)

    //public float ChaseRange = 4f; // 추적 범위
    //public float AttackRange = 4f; // 공격 가능한 범위

    public AudioSource nene;


    public void ReceiveFish(GameObject fish)
    {
        // 물고기 오브젝트를 받아서 변수에 저장 (player fire에서 받아와서)
        fishObject = fish;

        if (fishObject != null)
        {
            isBeingPulled = true;
            StartCoroutine(ResetIsBeingPulled()); // 추가 (7/23)
        }
    }

    private IEnumerator ResetIsBeingPulled() // 5초 후 false 초 조절하세요
    {
        yield return new WaitForSeconds(5.0f);
        isBeingPulled = false; // 끌려가냐마냐
        isCombatEnabled = true; // waypoint로 돌아가면서 공격하게
    }
    

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim.Play("idle");

        Delay = 30;
        // nene= this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        if (!isBeingPulled && 4 <= distance)
        {
            //ChasePlayer();
            if (distance > 4 && distance <= 8)
            {
                ChasePlayer();
                EG.Attack();
            }
            else if(distance > 8)
            {

                anim.Play("walk");
                if (isArrived == false)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(WayPoint1.transform.position - transform.position), 1);
                    transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

                    if (Vector3.Distance(transform.position, WayPoint1.transform.position) <= 0.5f)
                    {
                        isArrived = true;
                    }
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(WayPoint2.transform.position - transform.position), 1);
                    transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

                    if (Vector3.Distance(transform.position, WayPoint2.transform.position) <= 0.5f)
                    {
                        isArrived = false;
                    }
                }
            }
        }

        else
        {

        if (isCombat == false && !isBeingPulled)
        {
            anim.Play("walk");
            if (isArrived == false)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(WayPoint1.transform.position - transform.position), 1);
                transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

                if (Vector3.Distance(transform.position, WayPoint1.transform.position) <= 0.5f)
                {
                    isArrived = true;
                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(WayPoint2.transform.position - transform.position), 1);
                transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

                if (Vector3.Distance(transform.position, WayPoint2.transform.position) <= 0.5f)
                {
                    isArrived = false;
                }
            }
        }
        else
        {
            if (!isBeingPulled) // 추가 (끌려갈때는 공격 안하게)
            {
            Delay -= 1;
            if (Delay <= 0)
            {
                Delay = 30;
                    EG.Attack();
            }
            }
        }

        if (isBeingPulled && fishObject != null)
        {
            anim.Play("run");

            //위치!!!
            Vector3 targetPosition = fishObject.transform.position - (fishObject.transform.forward * pullDistance) + (Vector3.up * pullHeight);

            //겜블러 얼굴 물고기 쪽으로 돌아가게
            Vector3 directionToFish = fishObject.transform.position - transform.position;
            directionToFish.y = 0f;
            if (directionToFish != Vector3.zero)
            {
                Debug.Log("돌아감0");
                Quaternion targetRotation = Quaternion.LookRotation(directionToFish);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            // 랜덤
            float offsetX = Random.Range(-offsetRange, offsetRange);
            float offsetZ = Random.Range(-offsetRange, offsetRange);
            Vector3 randomOffset = new Vector3(offsetX, 0f, offsetZ);

            // 랜덤한 벡터 + 적 위치
            targetPosition += randomOffset;

            // 적의 위치 이동
            float step = pullSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // 적의 높이 제한 (있는 게 나음)
            float limitedHeight = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
            transform.position = new Vector3(transform.position.x, limitedHeight, transform.position.z);

        }

        //float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <= 4 && isCombatEnabled && !isBeingPulled)
        {
            isCombat = true;
            anim.CrossFade("hit2", 0.4f);
            Vector3 LockVector = Player.transform.position - transform.position;
            LockVector.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LockVector), 1);
            nene.Play();
        }
        else if ((distance > 4 && distance <= 8) && !isBeingPulled)
        {
            isCombat = true;
            anim.CrossFade("hit", 0.4f);
            Vector3 LockVector = Player.transform.position - transform.position;
            LockVector.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LockVector), 1);
            //    nene.Stop();
        }
        else
        {
            isCombat = false;
        }
        }//추가된괄호
    }

    void ChasePlayer()
    {
        anim.Play("run");

        Vector3 targetDirection = Player.transform.position - transform.position;
        targetDirection.y = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), 1);
        transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);
    }

    // void AttackPlayer()
    // {
    //     float distance = Vector3.Distance(Player.transform.position, transform.position);
    //     if (distance <= 4 && isCombatEnabled && !isBeingPulled)
    //     {
    //         isCombat = true;
    //         anim.CrossFade("hit2", 0.4f);
    //         Vector3 LockVector = Player.transform.position - transform.position;
    //         LockVector.y = 0;
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LockVector), 1);
    //     }
    //     else if ((distance > 4 && distance <= 8) && !isBeingPulled)
    //     {
    //         isCombat = true;
    //         anim.CrossFade("hit", 0.4f);
    //         Vector3 LockVector = Player.transform.position - transform.position;
    //         LockVector.y = 0;
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LockVector), 1);
    //     }
    //     else
    //     {
    //         isCombat = false;
    //     }
    // }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(gameObject);
            // Camera.main.GetComponent<score>.CurrentScore+=10;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Newbullet>()?.OnCollisionEnter(collision);
            TakeDamage(5);
        }

        // else if (collision.transform.CompareTag("Fish")) 원래 이거 수류탄!
        // {
        //     collision.gameObject.GetComponent<FishExplosion>().OnCollisionEnter(collision);
        //     TakeDamage(15);
        // }
    }
    private void OnControllerColliderHit(ControllerColliderHit collision){
        if(collision.rigidbody){
            TakeDamage(5);
        }
    }
}
