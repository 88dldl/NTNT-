using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    public int Health=50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 체력보기 
        Debug.Log(Health);
    }

    public void TakeDamage(int amount){
        Health-=amount;
        if(Health<=0){
            // Destroy(gameObject);
            // Camera.main.GetComponent<score>.CurrentScore+=10;
        }
    }
    public void OnCollisionEnter(Collision collision){
        if(collision.transform.CompareTag("Enemy")){
            // collision.gameObject.GetComponent<
            TakeDamage(5);
        } 
    }
}
