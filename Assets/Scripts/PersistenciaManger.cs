using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersistenciaManger : MonoBehaviour
{
    public static PersistenciaManger Instance { get; private set; }

    private int puntaje;
    private int nivelActual;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Inicializar los valores de puntaje y nivelActual al inicio del juego
            puntaje = GetInt("Puntaje");
            nivelActual = GetInt("Nivel", 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetPuntaje()
    {
        return puntaje;
    }

    public void SetPuntaje(int value)
    {
        puntaje = value;
        SetInt("Puntaje", puntaje);
    }

    public int GetNivelActual()
    {
        return nivelActual;
    }

    public void SetNivelActual(int value)
    {
        nivelActual = value;
        SetInt("Nivel", nivelActual);
    }

    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}




