using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 回復アイテムのクラス。Player の攻撃が当たったら Player の体力を回復する。
/// </summary>
public class HealItem : MonoBehaviour
{
    [Tooltip("回復量"), SerializeField] int _healPoints = 1;
    [SerializeField] PlayerHP _playerHP;

    public void GetHealItem()
    {
        _playerHP.Heal(_healPoints);
        //GameManager.Instance.PlayerHP.Heal(_healPoints);
    }
}
