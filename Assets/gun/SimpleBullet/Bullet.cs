using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitSpark;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            return;
        }

        if (collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>()?.TakeDamage(5);
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

    public void HitEnemy()
    {
        Instantiate(HitSpark, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
