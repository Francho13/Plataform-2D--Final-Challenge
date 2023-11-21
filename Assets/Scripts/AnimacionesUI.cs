using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject victory;

    private void Start()
    {
        LeanTween.moveX(victory.GetComponent<RectTransform>(),0,3.0f);

    }
}
