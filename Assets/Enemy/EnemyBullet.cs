using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject HitSpark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.tag=="Bullet"){
            return;
        }
        if(collision.transform.tag=="Player"){
            Camera.main.GetComponent<Health>().TakeDamage(50);
        }
        Instantiate(HitSpark,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
