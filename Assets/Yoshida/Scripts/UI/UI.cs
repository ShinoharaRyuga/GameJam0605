using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI の動きを制御するクラス。主に HP と Info
/// </summary>
public class UI : MonoBehaviour
{
    [Tooltip("Slider"), SerializeField] Slider _HpSlider = default;
    [Tooltip("InfoText に表示する Text"), SerializeField] Text _infoText = default; 
}
