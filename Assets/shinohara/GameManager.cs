using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("ステージ数")] int _maxStage = default;
    [SerializeField, Tooltip("各ステージの敵の数")] int[] _stageEnemyCount = default;
    [SerializeField, Tooltip("各ステージの背景")] GameObject[] _stageBackGround = default;
    [SerializeField, Tooltip("各ステージのスポーンマネージャー")] GameObject[] _stageSpawnManager = default;
    [SerializeField, Tooltip("フェードをさせるオブジェクト")] GameObject _fadeObj = default;
    [SerializeField] GameObject _playerPrefab = default;
    [SerializeField, Tooltip("ゲームリザルトUI")] GameObject _gameResult = default;
    PlayerHP _playerHP;
    Attackspace _attackspace;

    GameObject _currentBackGround = default;
    GameObject _currentSpawnManager = default;
    private float _playTime = 0.0f;
    private bool _isTimeCount = true;
    /// <summary>現在のステージ </summary>
    int _currentStage = 0;
    public PlayerHP PlayerHP { get => _playerHP; set => _playerHP = value; }
    public Attackspace Attackspace { get => _attackspace; set => _attackspace = value; }

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
            SceneManager.sceneLoaded += GameSceneLoad;
            DontDestroyOnLoad(this);
        }
    }
 
    /// <summary>ゲームシーンに遷移したらプレイヤーを生成する </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            var player = Instantiate(_playerPrefab, Vector2.zero, Quaternion.identity);
            _playerHP = player.GetComponent<PlayerHP>();
            _attackspace = player.GetComponent<Attackspace>();
        }
    }

    /// <summary>敵を倒した時に呼ばれる ステージ内に存在する敵の数を減らす</summary>
    public void ChangeEnemyCount()
    {
        _stageEnemyCount[_currentStage]--;      //敵の数を減らす

        if (_stageEnemyCount[_currentStage] <= 0) //ステージクリア
        {
            _currentStage++;
            StageChange();
        }
    }

    private void Start()
    {
        StageChange();
    }

    private void Update()
    {
        _playTime += Time.deltaTime;
    }

    public void StageChange()
    {
        if (_currentBackGround != null)
        {
            Destroy(_currentBackGround);
        }

        if (_currentSpawnManager != null)
        {
            Destroy(_currentBackGround);
        }

        if(_currentStage > _maxStage-1)
        {
            GameResult(true);
        }

        _currentBackGround = Instantiate(_stageBackGround[_currentStage], Vector3.zero, Quaternion.identity);
        _currentSpawnManager = Instantiate(_stageSpawnManager[_currentStage], Vector3.zero, Quaternion.identity);
        SpawnManager sm = _currentSpawnManager.GetComponent<SpawnManager>();
        sm.SetMaxSpawnCount(_stageEnemyCount[_currentStage]);

    }

    void GameResult(bool isClear)
    {
        _isTimeCount = false;
        GameObject resultUI = Instantiate(_gameResult, Vector3.zero,Quaternion.identity);
        resultUI.GetComponent<GameResult>().SetResultTime(_playTime);
    }
}
