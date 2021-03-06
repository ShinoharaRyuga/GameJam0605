using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("ステージ数")] int _maxStage = default;
    [SerializeField, Tooltip("各ステージの敵の数")] int[] _stageEnemyCounts = default;
    [SerializeField, Tooltip("各ステージの背景")] GameObject[] _stageBackGround = default;
    [SerializeField, Tooltip("各ステージのスポーンマネージャー")] GameObject[] _stageSpawnManager = default;
    [SerializeField, Tooltip("フェードインをさせるオブジェクト")] GameObject _fadeInObj = default;
    [SerializeField, Tooltip("フェードアウトをさせるオブジェクト")] GameObject _fadeOutObj = default;
    [SerializeField, Tooltip("フェードさせるオブジェクト")] GameObject _fadeObj = default;
    [SerializeField, Tooltip("プレイヤー死亡時に出すUI")] GameObject _gameOverUI = default;
    [SerializeField] GameObject _playerPrefab = default;
    [SerializeField, Tooltip("ゲームリザルトUI")] GameObject _gameResult = default;
    private GameObject _BGMPlayer = default;
    PlayerHP _playerHP;
    Attackspace _attackspace;

    GameObject _currentBackGround = default;
    GameObject _currentSpawnManager = default;
    int _currentEnemyCount = 0;
    float _playTime = 0.0f;
    bool _isTimeCount = true;
    GameObject _player = default;
    /// <summary>現在のステージ </summary>
    int _currentStage = -1;
    public PlayerHP PlayerHP { get => _playerHP; set => _playerHP = value; }
    public Attackspace Attackspace { get => _attackspace; set => _attackspace = value; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            SceneManager.sceneLoaded += GameSceneLoad;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        _playTime += Time.deltaTime;
    }

    /// <summary>ゲームシーンに遷移したらプレイヤーを生成する </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            _player = Instantiate(_playerPrefab, Vector2.zero, Quaternion.identity);
            _playerHP = _player.GetComponent<PlayerHP>();
            _attackspace = _player.GetComponent<Attackspace>();
            SetEnemyCount(_stageEnemyCounts[0]);
            StageChange();
        }
        else if (scene.name == "Title")
        {
            _currentStage = -1;
            Cursor.visible = true;
        }

        Instantiate(_fadeOutObj);
    }

    /// <summary>敵を倒した時に呼ばれる ステージ内に存在する敵の数を減らす</summary>
    public void ChangeEnemyCount()
    {
        _currentEnemyCount--;      //敵の数を減らす

        if (_currentEnemyCount <= 0) //ステージクリア
        {
            Instantiate(_fadeObj);
        }
    }
    
    /// <summary>プレイヤーが死亡したらゲームオーバーUIを表示する </summary>
    public void GameOver()
    {
        Instantiate(_gameOverUI);
        Destroy(_player);
        Cursor.visible = true;
    }

    public void InstantiateFadeInObj()
    {
        Instantiate(_fadeInObj);
    }

    public void StageChange()
    {
        _currentStage++;
        Debug.Log($"currentStage = {_currentStage}");

        if (_currentStage == 0) _playTime = 0;

        if (_currentStage == _maxStage-1)
        {
            _BGMPlayer = GameObject.Find("BGM");
            _BGMPlayer.GetComponent<BGMPlayer>().PlayLastStageBGM();
        }
        if (_currentStage >= _maxStage)
        {
            _BGMPlayer.GetComponent<BGMPlayer>().PlayResultBGM();
        }

        if (_currentBackGround != null)
        {
            Destroy(_currentBackGround);
        }

        if (_currentSpawnManager != null)
        {
            Destroy(_currentBackGround);
        }

        if (_currentStage > _maxStage - 1)
        {
            GameResult(true);
        }
        else
        {
            EnemySpawn();
        }
    }

    public void EnemySpawn()
    {
        SetEnemyCount(_stageEnemyCounts[_currentStage]);
        _currentBackGround = Instantiate(_stageBackGround[_currentStage], Vector3.zero, Quaternion.identity);
        _currentSpawnManager = Instantiate(_stageSpawnManager[_currentStage], Vector3.zero, Quaternion.identity);
        SpawnManager sm = _currentSpawnManager.GetComponent<SpawnManager>();
        sm.SetMaxSpawnCount(_stageEnemyCounts[_currentStage]);
    }

    void GameResult(bool isClear)
    {
        _isTimeCount = false;
        GameObject resultUI = Instantiate(_gameResult, Vector3.zero, Quaternion.identity);
        resultUI.GetComponent<GameResult>().SetResultTime(_playTime);
        Destroy(_player);
        Cursor.visible = true;
    }

    /// <summary>各ステージの敵総数を決める </summary>
    void SetEnemyCount(int count)
    {
        _currentEnemyCount = count;
    }
}
