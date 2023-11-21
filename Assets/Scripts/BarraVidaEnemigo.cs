using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{
    [SerializeField] private Image barimage;

    public void UpdateBarradeVida(float vidaMaxima, float vida)
    {
        barimage.fillAmount = vida / vidaMaxima;

    }
}
