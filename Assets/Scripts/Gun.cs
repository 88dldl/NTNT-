using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody Bullet;
    public AudioClip Gunshot;
    public float BulletSpeed;
    public GameObject GunSpark;
    void Start()
    {

    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody rb = (Rigidbody)Instantiate(Bullet, transform.position, transform.rotation);
            rb.velocity = transform.TransformDirection(new Vector3(0, 0, BulletSpeed));
            AudioSource.PlayClipAtPoint(Gunshot, transform.position);
            Instantiate(GunSpark, transform.position, transform.rotation);
        }
    }
}