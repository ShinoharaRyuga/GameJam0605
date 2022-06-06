using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 攻撃速度を早くするアイテムのクラス。Player の攻撃が当たったら Player の攻撃間隔を短くする。
/// </summary>
public class SpeedUpItem : MonoBehaviour
{
    [Tooltip("早くする間隔"), SerializeField] float _reduceTime = 0.2f;
    [SerializeField] Attackspace _attackSpace;

    public void GetSpeedUpItem()
    {
        _text = GetComponent<PlayerHP>();
        var currentspeed = GameManager.Instance.Attackspace.AttackInterval;
        var minspeedvalue = GameManager.Instance.Attackspace.AttackIntervalMin;
        //_text.GetComponent<PlayerHP>()._uiText.text = $"クールタイムが{_reduceTime}減少した！".ToString();
        _text.UiText.text = $"クールタイムが{_reduceTime}早くなった！";
        currentspeed -= _reduceTime;

        if(currentspeed < minspeedvalue)
        {
            currentspeed = minspeedvalue;
            _text.UiText.text = $"クールタイムは最速です";
        }
    }
}
