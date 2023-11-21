using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacionBotones : MonoBehaviour
{
    public void Salir()
    {

        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level 1 Phase 1");
    }
}
