using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("�X�e�[�W��")] int _maxStage = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̓G�̐�")] int[] _stageEnemyCounts = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̔w�i")] GameObject[] _stageBackGround = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̃X�|�[���}�l�[�W���[")] GameObject[] _stageSpawnManager = default;
    [SerializeField, Tooltip("�t�F�[�h�C����������I�u�W�F�N�g")] GameObject _fadeInObj = default;
    [SerializeField, Tooltip("�t�F�[�h�A�E�g��������I�u�W�F�N�g")] GameObject _fadeOutObj = default;
    [SerializeField, Tooltip("�t�F�[�h������I�u�W�F�N�g")] GameObject _fadeObj = default;
    [SerializeField] GameObject _playerPrefab = default;
    [SerializeField, Tooltip("�Q�[�����U���gUI")] GameObject _gameResult = default;
    PlayerHP _playerHP;
    Attackspace _attackspace;

    GameObject _currentBackGround = default;
    GameObject _currentSpawnManager = default;
    int _currentEnemyCount = 0;
    float _playTime = 0.0f;
    bool _isTimeCount = true;
    /// <summary>���݂̃X�e�[�W </summary>
    int _currentStage = 0;
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
            SetEnemyCount(_stageEnemyCounts[0]);
            StageChange();
        }
        else if (scene.name == "Title")
        {
            _currentStage = 0;
            Cursor.visible = true;
        }

        Instantiate(_fadeOutObj);
    }

    /// <summary>�G��|�������ɌĂ΂�� �X�e�[�W���ɑ��݂���G�̐������炷</summary>
    public void ChangeEnemyCount()
    {
        _currentEnemyCount--;      //�G�̐������炷

        if (_currentEnemyCount <= 0) //�X�e�[�W�N���A
        {
            _currentStage++;

            if (_currentStage < _stageEnemyCounts.Length)
            {
                SetEnemyCount(_stageEnemyCounts[_currentStage]);
            }

            StageChange();
        }

    }

    public void InstantiateFadeInObj()
    {
        Instantiate(_fadeInObj);
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

        if (_currentStage > _maxStage - 1)
        {
            GameResult(true);
        }
        else
        {
            _currentBackGround = Instantiate(_stageBackGround[_currentStage], Vector3.zero, Quaternion.identity);
            _currentSpawnManager = Instantiate(_stageSpawnManager[_currentStage], Vector3.zero, Quaternion.identity);
            SpawnManager sm = _currentSpawnManager.GetComponent<SpawnManager>();
            sm.SetMaxSpawnCount(_stageEnemyCounts[_currentStage]);
        }

        Instantiate(_fadeObj);
    }

    void GameResult(bool isClear)
    {
        _isTimeCount = false;
        GameObject resultUI = Instantiate(_gameResult, Vector3.zero, Quaternion.identity);
        resultUI.GetComponent<GameResult>().SetResultTime(_playTime);
    }

    /// <summary>�e�X�e�[�W�̓G���������߂� </summary>
    void SetEnemyCount(int count)
    {
        _currentEnemyCount = count;
    }
}
