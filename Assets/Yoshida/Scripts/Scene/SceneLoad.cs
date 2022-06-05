using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Button �ɃA�^�b�`���Ďg���N���X�B���O���w�肵�ăV�[�������[�h����
/// </summary>
public class SceneLoad : MonoBehaviour
{
    [Tooltip("���[�h����V�[����(string)"), SerializeField] string _loadSceneName = default;
    [Tooltip("�ҋ@����"), SerializeField] float _waitTime = 1;
    [Tooltip("�v�Z�p�^�C�}�[")] float _timer = 0f;

    public void LoadScene()
    {
        GameManager.Instance.InstantiateFadeInObj();
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        while (true)
        {
            yield return null;
            _timer += Time.deltaTime;

            if( _timer > _waitTime)
            {
                SceneManager.LoadScene(_loadSceneName);
                break;
            }
        }
    }
}
