using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 回復アイテムのクラス。Player の攻撃が当たったら Player の体力を回復する。
/// </summary>
public class HealItem : MonoBehaviour
{
    [Tooltip("回復量"), SerializeField] int _healPoint = 1;
    

    public void GetHealItem()
    {

    }
}
