using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorEscenas : MonoBehaviour
{
    [SerializeField] private Slider BarradeCarga;
    [SerializeField] private GameObject PaneldeCarga;
    
    public void CargarEscena(int sceneIndex)
    {
        PaneldeCarga.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            BarradeCarga.value = asyncOperation.progress;
            yield return null;
        }
    }
}

