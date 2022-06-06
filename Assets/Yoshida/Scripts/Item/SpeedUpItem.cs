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
        _attackSpace.SpeedUp(_reduceTime);
    }
}
