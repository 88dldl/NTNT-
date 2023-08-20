using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animation anim;

    public GameObject WayPoint1;// 웨이 포인트 설정
    public GameObject WayPoint2;// 웨이 포인트 설정
    public GameObject Player;

    public float MoveSpeed = 2.0f;
    public bool isArrived = false; //웨이포인트 도착여부
    public bool isCombat = false;

    public int Delay;
    public EnemyGun EG;
    //적체력
    public int Health = 15;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;

        anim.Play("idle");

        Delay = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCombat == false)
        {
            // Run
            anim.Play("walk");
            if (isArrived == false)
            {
                //waypoint1
                // 적 오브젝트의 rotation값 변경 -> 가려는 방향으로 회전
                //lerp 는 구면 선형 보간,lerp(자신의 회전값, 목표, 시간)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(WayPoint1.transform.position - transform.position), 1);
                transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

                //distance => 두 지점 사이 거리값 반환
                if (Vector3.Distance(transform.position, WayPoint1.transform.position) <= 0.5f)
                {
                    isArrived = true;
                }
            }
            else
            {
                //waypoint2
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
            Delay -= 1;
            if (Delay <= 0)
            {
                Delay = 30;
                EG.Attack();
            }
        }



        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <= 4)
        {
            isCombat = true;
            anim.CrossFade("hit", 0.4f);
            Vector3 LockVector = Player.transform.position - transform.position;
            LockVector.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LockVector), 1);
        }
        else
        {
            isCombat = false;
        }

    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(gameObject);
            // Camera.main.GetComponent<score>.CurrentScore+=10;
        }
    }
}