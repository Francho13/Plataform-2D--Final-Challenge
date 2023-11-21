using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;

    public TextMeshProUGUI lifetext;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;

        int porcentajeVida = Mathf.RoundToInt((cantidadVida / slider.maxValue) * 100f);

        // Actualiza el TextMeshPro con el porcentaje de vida
        lifetext.text = porcentajeVida.ToString() + "%"; // Mostrar el porcentaje como número entero
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
