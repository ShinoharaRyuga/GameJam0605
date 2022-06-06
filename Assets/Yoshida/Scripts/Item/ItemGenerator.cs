using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item �𐶐�����N���X�B
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�A�C�e���̃v���n�u")] GameObject[] _items = default;
    [SerializeField, Tooltip("�A�C�e���̏o���ʒu")] Transform[] _spawnPoints = default;
    [SerializeField, Tooltip("�A�C�e���̐�������")] float _spawnInterval = 10f;
    [Tooltip("�v�Z�p�^�C�}�[")] float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _spawnInterval)
        {
            Spawn();
            _timer = 0f;
        }
    }

    void Spawn()
    {
        int randomItem = Random.Range(0, _items.Length);
        int randomSpawn = Random.Range(0, _spawnPoints.Length);

        Instantiate(_items[randomItem], _spawnPoints[randomSpawn]);
    }
}
