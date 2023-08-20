using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{


    public Rigidbody Bullet;
    //public AudioClip GunShot;
    public float BulletSpeed;
    public GameObject GunSpark;
    public GameObject Player;
    public float shootingDistanceMin = 4f;
    public float shootingDistanceMax = 8f;
    public float fireRate = 1f; // 발사 속도 조절

    private float nextFireTime; // 다음 발사 시간
    // private float deleteTime=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time; // 시작 시간으로 초기화
        // Destroy(gameObject, deleteTime);
    }   

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance > shootingDistanceMin && distance <= shootingDistanceMax && Time.time >= nextFireTime)
        {
            Rigidbody rb = Instantiate(Bullet, transform.position, transform.rotation);
            rb.velocity = transform.TransformDirection(new Vector3(0, BulletSpeed, 0));
            //AudioSource.PlayClipAtPoint(GunShot,transform.position);
            Instantiate(GunSpark, transform.position, transform.rotation);

            nextFireTime = Time.time + 1f / fireRate; // 다음 발사 시간 갱신
        }
    }

    // public void OnCollisionEnter(Collision collision){
    //     if(collision.transform.tag=="Ground"){
    //         Destroy(gameObject);
    //     }
    // }
}
