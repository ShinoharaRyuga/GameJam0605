using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Button にアタッチして使うクラス。名前を指定してシーンをロードする
/// </summary>
public class SceneLoad : MonoBehaviour
{
    [Tooltip("ロードするシーン名(string)"), SerializeField] string _loadSceneName = default;
    [Tooltip("待機時間"), SerializeField] float _waitTime = 1;
    [Tooltip("計算用タイマー")] float _timer = 0f;

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
