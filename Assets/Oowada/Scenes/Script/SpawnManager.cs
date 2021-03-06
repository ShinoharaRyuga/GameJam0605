using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private string _SpawnPointTag = "";
    [SerializeField] private List<GameObject> _enemy;
    [SerializeField] private GameObject _enemyBOSS = null;
    [SerializeField] private Vector2 _spawnTimeRange = new Vector2(1, 5);
    [SerializeField] private int _maxSpawnCount = 10;
    [SerializeField] public float _startDelay = 5;

    public List<GameObject> _spawnPoints;
    public float _currentTime = 0;
    public float _targetTime = 1;
    public int _spawnCount = 0;

    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag(_SpawnPointTag);
        _spawnPoints  = new List<GameObject>(temp);
        _targetTime = _startDelay;
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
            
            if (_spawnCount == _maxSpawnCount -1 && _enemyBOSS != null)
            {
                Instantiate(_enemyBOSS, _pos, Quaternion.identity);
            }
            else
            {
                Instantiate(_enemy[enemyrandom], _pos, Quaternion.identity);
            }
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
