using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �U�����x�𑁂�����A�C�e���̃N���X�BPlayer �̍U�������������� Player �̍U���Ԋu��Z������B
/// </summary>
public class SpeedUpItem : MonoBehaviour
{
    [Tooltip("��������Ԋu"), SerializeField] float _reduceTime = 0.2f;
    [SerializeField] Attackspace _attackSpace;

    public void GetSpeedUpItem()
    {
        _text = GetComponent<PlayerHP>();
        var currentspeed = GameManager.Instance.Attackspace.AttackInterval;
        var minspeedvalue = GameManager.Instance.Attackspace.AttackIntervalMin;
        //_text.GetComponent<PlayerHP>()._uiText.text = $"�N�[���^�C����{_reduceTime}���������I".ToString();
        _text.UiText.text = $"�N�[���^�C����{_reduceTime}�����Ȃ����I";
        currentspeed -= _reduceTime;

        if(currentspeed < minspeedvalue)
        {
            currentspeed = minspeedvalue;
            _text.UiText.text = $"�N�[���^�C���͍ő��ł�";
        }
    }
}
