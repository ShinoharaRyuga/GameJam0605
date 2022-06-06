using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �񕜃A�C�e���̃N���X�BPlayer �̍U�������������� Player �̗̑͂��񕜂���B
/// </summary>
public class HealItem : MonoBehaviour
{
    [Tooltip("�񕜗�"), SerializeField] int _healPoints = 1;
    UI _text;
    [SerializeField] GameObject _player = default;  //�e�X�g�p�B�}�X�^�[�ł�SpeedItem.cs�̂悤�ɂ��Ă�

    public void GetHealItem()
    {
        var hp = _player.GetComponent<PlayerHP>().HP;   //�e�X�g�p�B�}�X�^�[�ł�SpeedItem.cs�̂悤�ɂ��Ă�
        var hpValue = _player.GetComponent<PlayerHP>().HPmax;   //�e�X�g�p�B�}�X�^�[�ł�SpeedItem.cs�̂悤�ɂ��Ă�
        hp += _healPoints;
        _text.GetComponent<UI>()._infoText.text = $"{_healPoints} �񕜂����I";

        if(hp > hpValue)
        {
            hp = hpValue;
            _text._infoText.text = $"HP�͂������ɍő�ł�".ToString();
        }
    }
}
