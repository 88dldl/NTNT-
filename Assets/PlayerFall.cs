using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFall : MonoBehaviour
{
    public float fall = -10f; // y 값으로 떨어짐 비교

    void Update()
    {
        if (transform.position.y < fall)
        {
            SceneManager.LoadScene(8);
        }
    }
}
