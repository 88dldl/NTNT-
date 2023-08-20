using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountGambler : MonoBehaviour
{
    [SerializeField] int countgambler;
    [SerializeField] Text countText;
    [SerializeField] int maxcount;

    void Start()
    {
        maxcount = GameObject.FindGameObjectsWithTag("tmpcount").Length;
        countgambler =maxcount;
        countText.text = countgambler.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        countgambler=GameObject.FindGameObjectsWithTag("tmpcount").Length;      
        countText.text = countgambler.ToString()+"/"+maxcount.ToString();
        // Ending();
    }
}
