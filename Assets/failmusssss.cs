using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failmusssss : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource readyAudio;
    // Start is called before the first frame update
    void Start()
    {
        readyAudio = GameObject.FindObjectOfType<Readymusic>().Ready;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(readyAudio.gameObject);
    }
}
