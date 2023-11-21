using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Puntaje : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int puntaje = PersistenciaManger.Instance.GetPuntaje();
        textMesh.text = puntaje.ToString("0");
    }

    public void SumarPuntos(int puntosEntrada)
    {
        int puntajeActual = PersistenciaManger.Instance.GetPuntaje();
        puntajeActual += puntosEntrada;
       PersistenciaManger.Instance.SetPuntaje(puntajeActual);
    }
}








