using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [SerializeField, Tooltip("�e�X�e�[�W�̓G�̐�")] int[] _stageEnemyCount = default;
    [SerializeField, Tooltip("�t�F�[�h��������I�u�W�F�N�g")] GameObject _fadeObj = default;
    /// <summary>���݂̃X�e�[�W </summary>
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
