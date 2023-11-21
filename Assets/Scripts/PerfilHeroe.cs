using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilHeroe", menuName ="SO/PerfilHeroe")]
public class PerfilHeroe : ScriptableObject
{
    [Header("Experiencia")]

    [SerializeField] private int currentExperience;

    [SerializeField] private int experienceToNextLevel;

    [SerializeField] private int currentLevel;
    public int CurrentLevel { get => CurrentLevel1; }
    public int CurrentExperience { get => currentExperience; set => currentExperience = value; }
    public int ExperienceToNextLevel { get => experienceToNextLevel; set => experienceToNextLevel = value; }
    public int CurrentLevel1 { get => currentLevel; set => currentLevel = value; }
   

    
}
