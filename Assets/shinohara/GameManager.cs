using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("�X�e�[�W��")] int _maxStage = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̓G�̐�")] int[] _stageEnemyCount = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̔w�i")] GameObject[] _stageBackGround = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̃X�|�[���}�l�[�W���[")] GameObject[] _stageSpawnManager = default;
    [SerializeField, Tooltip("�t�F�[�h��������I�u�W�F�N�g")] GameObject _fadeObj = default;
    [SerializeField] GameObject _playerPrefab = default;
    [SerializeField, Tooltip("�Q�[�����U���gUI")] GameObject _gameResult = default;
    PlayerHP _playerHP;
    Attackspace _attackspace;

    GameObject _currentBackGround = default;
    GameObject _currentSpawnManager = default;
    private float _playTime = 0.0f;
    private bool _isTimeCount = true;
    /// <summary>���݂̃X�e�[�W </summary>
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
 
    /// <summary>�Q�[���V�[���ɑJ�ڂ�����v���C���[�𐶐����� </summary>
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

    /// <summary>�G��|�������ɌĂ΂�� �X�e�[�W���ɑ��݂���G�̐������炷</summary>
    public void ChangeEnemyCount()
    {
        _stageEnemyCount[_currentStage]--;      //�G�̐������炷

        if (_stageEnemyCount[_currentStage] <= 0) //�X�e�[�W�N���A
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
