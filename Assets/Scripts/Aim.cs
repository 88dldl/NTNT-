using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Texture2D AimTexture;
    public Rect AimRect; 
    // Start is called before the first frame update
    void Start()
    {
        AimRect = new Rect ((Screen.width - AimTexture.width) / 2, (Screen.height - AimTexture.height) / 2, AimTexture.width, AimTexture.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() 
    {
        GUI.DrawTexture(AimRect, AimTexture);
    }
}
