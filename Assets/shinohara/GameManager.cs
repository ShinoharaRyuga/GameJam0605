using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("各ステージの敵の数")] int[] _stageEnemyCount = default;
    [SerializeField, Tooltip("フェードをさせるオブジェクト")] GameObject _fadeObj = default;
    /// <summary>現在のステージ </summary>
    int _currentStage = 0;

    // GameObject _player => GetComponent<GameObject>();
    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_fadeObj);
        }
    }

    /// <summary>敵を倒した時に呼ばれる ステージ内に存在する敵の数を減らす</summary>
    public void ChangeEnemyCount()
    {
        _stageEnemyCount[_currentStage]--;      //敵の数を減らす

        if (_stageEnemyCount[_currentStage] <= 0) //ステージクリア
        {
            _currentStage++;
        }
    }
}
