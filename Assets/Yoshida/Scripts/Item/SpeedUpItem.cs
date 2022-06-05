using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �U�����x�𑁂�����A�C�e���̃N���X�BPlayer �̍U�������������� Player �̍U���Ԋu��Z������B
/// </summary>
public class SpeedUpItem : MonoBehaviour
{
    [Tooltip("��������Ԋu"), SerializeField] float _reduceTime = 0.2f;


    public void GetSpeedUpItem()
    {
        var currentspeed = GameManager.Instance.Attackspace.AttackInterval;
        var minspeedvalue = GameManager.Instance.Attackspace.AttackIntervalMin;
        currentspeed -= _reduceTime;

        if(currentspeed < minspeedvalue)
        {
            currentspeed = minspeedvalue;
            Debug.Log("Speed�͍ő�");
        }
    }
}
