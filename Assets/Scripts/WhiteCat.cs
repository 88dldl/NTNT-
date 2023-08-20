using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class WhiteCat : MonoBehaviour
{

    private Animation anim;
    public GameObject Player;
    public float MoveSpeed = 2.0f;
    public bool isArrived = false;
    public bool isCombat = false;

    public int Health = 15;
    public int Delay;
    public bool check = false;
    private GameObject fishObject; // 물고기 오브젝트를 저장할 변수 (player fire에서 받아옴)

    public bool isBeingPulled = false; // 끌려가는 중인지
    private float pullSpeed = 5f; // 끌어당기는 속도
    private float pullDistance = 1.5f; // 물고기와 적 사이 거리
    private float pullHeight = 5f; // 적이 물고기보다 높이 떠 있는 거리
    private float minHeight = 0f; // 적의 최소 높이
    private float maxHeight = 0.2f; // 적의 최대 높이
    public float offsetRange = 0.1f; // 랜덤하게 위치하려고 씀
    public bool isCombatEnabled = true; // 적이 플레이어를 공격할 수 있는지 (true면 공격 가능, false면 공격 불가능)
    public GameObject fishOb;
    public GameObject perish; // 폭발 오브젝트를 할당할 변수

    private int currentNode = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    public List<Transform> waypoint = new List<Transform>();  //위치정보를 가지고 있는 리스트 선언
    public Transform fishwaypoint;

    public Image ImageDot;

    void Start()
    {
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.Loop;
        // anim.Play("idle");

        Delay = 30;

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        //agent.angularSpeed = turnSpeed; // 회전 속도 설정
        //agent.speed = moveSpeed; // 이동 속도 설정
        agent.stoppingDistance = pullDistance; // 도착 거리 설정
        agent.autoRepath = true; // 경로가 변경될 때마다 다시 경로 계산
                                 //GotoNext();
    }
    void Update()
    {
        fishObject = fishOb.GetComponent<PlayerFire>().moveFish;

        if (fishObject != null)
        {
            isBeingPulled = true;
        }

        if (isBeingPulled && fishObject != null)
        {
            float distanceToFish = Vector3.Distance(transform.position, fishObject.transform.position);
            // Debug.Log(distanceToFish);
            if (distanceToFish <= 8)
            {
                anim.Play("Walk");

                Vector3 targetPosition = fishObject.transform.position;

                agent.isStopped = false;
                agent.destination = targetPosition;
                if (distanceToFish <= 2)
                {
                    anim.Stop();
                    agent.isStopped = true;
                }
            }
            agent.isStopped = false;
            isBeingPulled = false;
            isCombatEnabled = false;
        }
        // agent.isStopped = false;
        // ReceiveFish();
        //Debug.Log(isBeingPulled);
        if (!agent.pathPending && agent.remainingDistance < 2f) //목표지점까지 남은거리
        {
            anim.Play("Walk");
            GotoNext(); //목적지까지의 거리가 2이하거나 도착했으면 함수실행
        }
        if (currentNode == waypoint.Count)
        {
            currentNode = 0;
            if (currentNode == 1)
                currentNode = 0;
        }
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        
        if (!isBeingPulled && 4 <= distance)
        {
                isCombatEnabled = false;
                agent.isStopped = false;
                isCombat = false;
                if (check)
                {
                    agent.SetDestination(waypoint[currentNode].position);
                    check = false;
                }
                //agent.destination = waypoint[currentNode].position;
                if (!agent.pathPending && agent.remainingDistance < 2f)
                {
                    anim.Play("Walk");
                    GotoNext(); //목적지까지의 거리가 2이하거나 도착했으면 함수실행
                }
                if (currentNode == waypoint.Count)
                {
                    currentNode = 0;
                    if (currentNode == 1)
                        currentNode = 0;
                }
        }
        else
        {

            if (!isBeingPulled) // 추가 (끌려갈때는 공격 안하게)
            {
                isCombatEnabled = true;
                Delay -= 1;
                if (Delay <= 0)
                {
                    Delay = 30;
                }
            }
        }

    }

    void GotoNext()
    {
        agent.destination = waypoint[currentNode].position;
        currentNode = (currentNode + 1);
    }
    //기즈모 부분은 웨이포인트 설정입니다.
    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoint.Count; i++)
        {
            Gizmos.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            Gizmos.DrawSphere(waypoint[i].transform.position, 2);
            Gizmos.DrawWireSphere(waypoint[i].transform.position, 20f);

            if (i < waypoint.Count - 1)
            {
                if (waypoint[i] && waypoint[i + 1])
                {
                    Gizmos.color = Color.red;
                    if (i < waypoint.Count - 1)
                        Gizmos.DrawLine(waypoint[i].position, waypoint[i + 1].position);
                    if (i < waypoint.Count - 2)
                    {
                        Gizmos.DrawLine(waypoint[waypoint.Count - 1].position, waypoint[0].position);
                    }
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            GameObject explosion = Instantiate(perish, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(ImageDot.gameObject);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Newbullet>()?.OnCollisionEnter(collision);
            TakeDamage(5);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.rigidbody)
        {
            TakeDamage(5);
        }
    }
}