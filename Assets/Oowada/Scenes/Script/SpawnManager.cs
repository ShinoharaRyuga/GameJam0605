using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private string _SpawnPointTag = "";
    [SerializeField] private List<GameObject> _enemy;
    [SerializeField] private Vector2 _spawnTimeRange = new Vector2(1, 5);
    [SerializeField] private int _maxSpawnCount = 10;

    public List<GameObject> _spawnPoints;
    public float _currentTime = 0;
    public float _targetTime = 1;
    public int _spawnCount = 0;

    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag(_SpawnPointTag);
        _spawnPoints  = new List<GameObject>(temp);
    }

    private void Update()
    {
        if(_spawnCount < _maxSpawnCount)
        {
            SpawnUpdate();
        }
    }

    private void SpawnUpdate()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _targetTime)
        {
            int random = Random.Range(0, _spawnPoints.Count);
            Vector3 _pos = _spawnPoints[random].transform.position;
            int enemyrandom = Random.Range(0, _enemy.Count);
            Instantiate(_enemy[enemyrandom], _pos, Quaternion.identity);
            _currentTime = 0;
            _targetTime = Random.Range(_spawnTimeRange.x, _spawnTimeRange.y);
            _spawnCount++;
        }
    }

    public void SetMaxSpawnCount(int maxSpawnCount)
    {
        _maxSpawnCount = maxSpawnCount;
    }
}
