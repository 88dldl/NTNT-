using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScratchFire : MonoBehaviour
{
    public List<GameObject> tmpEnemy;
    public GameObject enemy;
    public Image Scratch;
    public float shortDis;
    // Start is called before the first frame update
    void Start()
    {
        Scratch.color = Color.clear;        
    }

    // Update is called once per frame
    void Update()
    {
        tmpEnemy = new List<GameObject>(GameObject.FindGameObjectsWithTag("tmpcount"));
        shortDis = Vector3.Distance(gameObject.transform.position, tmpEnemy[0].transform.position); // 첫번째를 기준으로 잡아주기 
 
        enemy = tmpEnemy[0]; // 첫번째를 먼저 
 
        foreach (GameObject found in tmpEnemy)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
 
            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                enemy = found;
                shortDis = Distance;
            }
        }
        if(shortDis<5f){
            if(Input.GetKeyDown(KeyCode.Tab)){
                enemy.GetComponentInParent<finalenemy>().TakeDamage(8);
                StartCoroutine(waitFor());
            }
        }
        // foreach (GameObject found in tmpEnemy)
        // {
        //     float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);
        //     Debug.Log(Distance);
        //     if (Distance < 25.0f) // 위에서 잡은 기준으로 거리 재기
        //     {
        //         waitFor();
        //     }
        // }
    }
    IEnumerator waitFor(){
            Scratch.color = new Color(1,0,0,UnityEngine.Random.Range(0.5f,0.6f));
            yield return new WaitForSeconds(0.1f);
            Scratch.color = Color.clear;
    }
}
