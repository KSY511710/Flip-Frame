using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startscene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("GAME");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Help");
        }
    }
}