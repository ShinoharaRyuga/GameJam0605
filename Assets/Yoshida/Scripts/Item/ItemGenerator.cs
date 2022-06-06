using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item を生成するクラス。
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("アイテムのプレハブ")] GameObject[] _items = default;
    [SerializeField, Tooltip("アイテムの出現位置")] Transform[] _spawnPoints = default;
    [SerializeField, Tooltip("アイテムの生成時間")] float _spawnInterval = 10f;
    [Tooltip("計算用タイマー")] float _timer = 0f;

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
