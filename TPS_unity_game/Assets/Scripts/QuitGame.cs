using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Start()
    {   
        Invoke("ExitGame", 3f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
