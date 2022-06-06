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
    [SerializeField ,Tooltip("�A�C�e���̐�������")] float _itemLifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, _itemLifeTime);
    }

    public void GetHealItem()
    {
        GameManager.Instance.PlayerHP.Heal(_healPoints);
        Destroy(gameObject);
    }
}
