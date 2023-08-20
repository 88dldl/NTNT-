using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{None=-1,Idle = 0,Wander, }
public class TargetControl : MonoBehaviour
{
    private EnemyState enemyState = EnemyState.None; // 현재 적 행동

    // private Status status; // 이동속도 등 정보
    private UnityEngine.AI.NavMeshAgent navMeshAgent; // 이동제어를 위함

    private Animation anim;

    private void Start(){
        anim= GetComponent<Animation>();
        anim.wrapMode=WrapMode.Loop;
        // status = GetComponent<Status>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateRotation=false;
    }

    private void OnEnable(){
        // 적이 활성화 될떄 상태를 대기로 설정
        ChangeState(EnemyState.Idle);
    }
    private void OnDisable(){
        // 적이 비활성화 될떄 현재 진행중인 상태 종료, none으로 변경 
        StopCoroutine(enemyState.ToString());

        enemyState = EnemyState.None;
    }

    public void ChangeState(EnemyState newState){
        // 현재 재생중인 상태와 바꾸려는 상태가 같을때 가만히 
        if(enemyState ==newState) return ; 
        StopCoroutine(enemyState.ToString());
        enemyState=newState;
        StartCoroutine(enemyState.ToString());
    }
    private IEnumerator Idle(){
        StartCoroutine("AutoChangeFromIdleToWander");
        while(true){
            // 대기일때하는 행동
            anim.Play("idle");
            yield return null;
        }
    }
    private IEnumerator AutoChangeFromIdleToWander(){
        int changeTime = Random.Range(1,5); // 대기 시간

        yield return new WaitForSeconds(changeTime);
        ChangeState(EnemyState.Wander);
    }

    private IEnumerator Wander(){
        float currentTime = 0;
        float maxTime = 10;

        // 이동속도 설정
        // navMeshAgent.speed = status.WalkSpeed;
        //목표위치 설정
        navMeshAgent.SetDestination(CalculateWanderPosition());

        // 목표위치로 회전
        Vector3 to = new Vector3(navMeshAgent.destination.x,0,navMeshAgent.destination.z);
        Vector3 from = new Vector3(transform.position.x,0,transform.position.z);
        transform.rotation=Quaternion.LookRotation(to-from);

        while(true){
            currentTime +=Time.deltaTime;
            // 목표위치 근접하게 도달, 너무 오랜시간동안 배회하기 상태에 머물떄
            to = new Vector3(navMeshAgent.destination.x,0,navMeshAgent.destination.z);
            from = new Vector3(transform.position.x,0,transform.position.z);
            if((to-from).sqrMagnitude<0.01f||currentTime>=maxTime){
                ChangeState(EnemyState.Idle);
            }
            yield return null;
        }
        }

        private Vector3 CalculateWanderPosition(){
            float wanderRadius=10; 
            int wanderJitter=0; // 선택된 각도
            int wanderJitterMin=0;
            int wanderJitterMax=360;

            // 적캐릭터가 있는 월드의 중심위치와 크기
            Vector3 rangePosition =Vector3.zero;
            Vector3 rangeScale = Vector3.one*100.0f;

            // 자신 위치를 중심으로 반지름 거리 , 선택된 각도에 위치한 좌표를 목표지점으로 설정
            wanderJitter = Random.Range(wanderJitterMin,wanderJitterMax);
            Vector3 targetPosition = transform.position+SetAngle(wanderRadius,wanderJitter);

            // 생성된 목표위치가 자신의 이동구역을 벗어나지 않게 조절
            targetPosition.x=Mathf.Clamp(targetPosition.x,rangePosition.x-rangeScale.x*0.5f,rangePosition.x+rangeScale.x*0.5f);
            targetPosition.y=0.0f;
            targetPosition.z=Mathf.Clamp(targetPosition.z,rangePosition.z-rangeScale.z*0.5f,rangePosition.z+rangeScale.z*0.5f);

            return targetPosition;
        }

        private Vector3 SetAngle(float radius,int angle){
            Vector3 position = Vector3.zero;

            position.x=Mathf.Cos(angle)*radius;
            position.z=Mathf.Sin(angle)*radius;

            return position;
        }
    private void OnDrawGizos(){
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position,navMeshAgent.destination-transform.position);
    }


}
