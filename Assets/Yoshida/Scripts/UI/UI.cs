using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI �̓����𐧌䂷��N���X�B��� HP �� Info
/// </summary>
public class UI : MonoBehaviour
{
    [Tooltip("Slider"), SerializeField] Slider _HpSlider = default;
    [Tooltip("InfoText �ɕ\������ Text"), SerializeField] Text _infoText = default; 
}
