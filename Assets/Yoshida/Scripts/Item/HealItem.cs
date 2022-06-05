using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 回復アイテムのクラス。Player の攻撃が当たったら Player の体力を回復する。
/// </summary>
public class HealItem : MonoBehaviour
{
    [Tooltip("回復量"), SerializeField] int _healPoints = 1;

    [SerializeField] GameObject _player = default;  //テスト用。マスターではSpeedItem.csのようにしてね

    public void GetHealItem()
    {
        var hp = _player.GetComponent<PlayerHP>().HP;   //テスト用。マスターではSpeedItem.csのようにしてね
        var hpValue = _player.GetComponent<PlayerHP>().HPmax;   //テスト用。マスターではSpeedItem.csのようにしてね
        hp += _healPoints;
        Debug.Log($"{_healPoints}回復した");

        if(hp > hpValue)
        {
            hp = hpValue;
            Debug.Log("HPは最大");
        }
    }
}
