using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI の動きを制御するクラス。主に HP と Info
/// </summary>
public class UI : MonoBehaviour
{
    [Tooltip("PlayerのGameObject(テスト用)"), SerializeField] GameObject _player;
    [Tooltip("Slider"), SerializeField] Slider _hpSlider = default;
    [Tooltip("InfoText に表示する Text"), SerializeField] Text _infoText = default;

    private void Start()
    {
        _hpSlider.maxValue = _player.GetComponent<PlayerHP>().HPmax;
        _hpSlider.value = _player.GetComponent<PlayerHP>().HPmax;
    }

}
