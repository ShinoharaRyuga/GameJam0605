using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̓G�̐�")] int[] _stageEnemyCount = default;
    [SerializeField, Tooltip("�t�F�[�h��������I�u�W�F�N�g")] GameObject _fadeObj = default;
    [SerializeField] GameObject _playerPrefab = default;
    PlayerHP _playerHP;
    Attackspace _attackspace;
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
        }
    }
}
