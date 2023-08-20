using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemusic : MonoBehaviour
{
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
