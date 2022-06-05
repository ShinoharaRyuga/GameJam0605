using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃速度を早くするアイテムのクラス。Player の攻撃が当たったら Player の攻撃間隔を短くする。
/// </summary>
public class QuickItem : MonoBehaviour
{
    [Tooltip("早くする間隔"), SerializeField] int _reduceTime = 1;


    public void GetQuickItem()
    {

    }
}
