using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jjinmack : MonoBehaviour
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

    private bool shouldDestroy = false;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        anim.Play("idle");

        Delay = 30;
    }

    void Update()
    {
        if (Health <= 0)
        {
            // 제거를 위해 게임 오브젝트를 비활성화하고 shouldDestroy 변수를 true로 설정
            gameObject.SetActive(false);
            shouldDestroy = true;
        }
        
        if (isCombat == false)
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

        // shouldDestroy 변수가 true인 경우에는 다음 프레임에서 게임 오브젝트를 제거
        if (shouldDestroy)
        {
            Destroy(gameObject);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Newbullet>().HitEnemy();
            TakeDamage(5);
        }
    }
}
