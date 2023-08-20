using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet : MonoBehaviour
{
    //public GameObject HitSpark;
    private int damageAmount = 5;
    public float delay=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,delay);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            return;
        }
        if (collision.transform.tag == "Player")
        {
            //Camera.main.GetComponent<Health>().TakeDamage(5);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        //Instantiate(HitSpark, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
