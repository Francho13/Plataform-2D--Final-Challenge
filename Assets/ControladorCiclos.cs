using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControladorCicloDia : MonoBehaviour
{
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private CicloDia[] ciclosDia;
    [SerializeField] private float tiempoPorCiclo;

    private int cicloActual = 0;
    private int cicloSiguiente = 1;

    private void Start()
    {
        luzGlobal.color = ciclosDia[0].colorCiclo;
        StartCoroutine(CicloDiaNoche());
    }

    private IEnumerator CicloDiaNoche()
    {
        while (true)
        {
            float elapsedTime = 0;
            Color inicioColor = ciclosDia[cicloActual].colorCiclo;
            Color finalColor = ciclosDia[cicloSiguiente].colorCiclo;

            while (elapsedTime < tiempoPorCiclo)
            {
                float t = elapsedTime / tiempoPorCiclo;
                Color nuevoColor = new Color(
                    Mathf.Lerp(inicioColor.r, finalColor.r, t),
                    Mathf.Lerp(inicioColor.g, finalColor.g, t),
                    Mathf.Lerp(inicioColor.b, finalColor.b, t)
                );
                luzGlobal.color = nuevoColor;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cicloActual = cicloSiguiente;
            IncrementarCicloSiguiente();
        }
    }

    private void IncrementarCicloSiguiente()
    {
        cicloSiguiente = (cicloSiguiente + 1) % ciclosDia.Length;
    }
}
