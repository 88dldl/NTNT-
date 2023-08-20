using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newbullet : MonoBehaviour
{
    public GameObject HitSpark;
    public float lifetime = 4f;

    void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    void Update()
    {

    }

    void DestroyBullet()
    {
        // 총알 파괴
        Destroy(gameObject);
    }

    public void HitEnemy()
    {
        Instantiate(HitSpark, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<finalenemy>()?.TakeDamage(5);
        }
        else if (collision.transform.CompareTag("TrashCan"))
        {
            // 쓰레기통
            TrashCan trashCan = collision.gameObject.GetComponent<TrashCan>();
            if (trashCan != null)
            {
                trashCan.AttackTrashCan(collision);
            }
        }

        Instantiate(HitSpark, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}