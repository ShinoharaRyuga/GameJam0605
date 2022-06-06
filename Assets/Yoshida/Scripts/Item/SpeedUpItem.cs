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
        _attackSpace.SpeedUp(_reduceTime);
    }
}
