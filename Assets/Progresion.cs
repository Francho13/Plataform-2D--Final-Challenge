using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Progresion : MonoBehaviour
{
    [SerializeField] private PerfilHeroe perfilheroe;

    public PerfilHeroe PerfilHeroe { get => perfilheroe; }

    [Header("Efecto de Sonido")]

    [SerializeField] private AudioClip levelup;

    [Header("Textos")]
    public Slider experienceSlider; // Agrega una referencia al Slider
    public TextMeshProUGUI currentExperienceText; // Referencia al TextMeshPro para el número actual de experiencia
    public TextMeshProUGUI levelText; // Referencia al TextMeshPro para el número de nivel
    


    void Update()
    {
        experienceSlider.value = perfilheroe.CurrentExperience;

        // Actualiza el TextMeshPro para el número actual de experiencia
        currentExperienceText.text = perfilheroe.CurrentExperience.ToString() + "/" + perfilheroe.ExperienceToNextLevel.ToString();

        experienceSlider.maxValue = perfilheroe.ExperienceToNextLevel;

        levelText.text = " "  + perfilheroe.CurrentLevel1.ToString();
    }

    public void GainExperience(int experience)
    {
        perfilheroe.CurrentExperience += experience;

        if (perfilheroe.CurrentExperience >= perfilheroe.ExperienceToNextLevel)
        {
            LevelUp();
            ControladorSonido.Instance.EjecutarSonido(levelup);
           
        }

        
    }


    private void LevelUp()
    {

        perfilheroe.CurrentLevel1++;
        perfilheroe.CurrentExperience -= perfilheroe.ExperienceToNextLevel;
        perfilheroe.ExperienceToNextLevel += 50; 
        
    }
}

