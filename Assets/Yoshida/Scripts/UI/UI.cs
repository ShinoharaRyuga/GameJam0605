using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI �̓����𐧌䂷��N���X�B��� HP �� Info
/// </summary>
public class UI : MonoBehaviour
{
    [Tooltip("Player��GameObject(�e�X�g�p)"), SerializeField] GameObject _player;
    [Tooltip("Slider"), SerializeField] Slider _hpSlider = default;
    [Tooltip("InfoText �ɕ\������ Text"), SerializeField] Text _infoText = default;

    private void Start()
    {
        _hpSlider.maxValue = _player.GetComponent<PlayerHP>().HPmax;
        _hpSlider.value = _player.GetComponent<PlayerHP>().HPmax;
    }

}
