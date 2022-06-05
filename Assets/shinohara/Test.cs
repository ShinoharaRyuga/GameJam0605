using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public static Test Instance = default;
    [SerializeField] GameObject _fadeIn = default;
    [SerializeField] GameObject _fadeOut = default;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SceneLoad());
        }
    }

    /// <summary>ゲームシーンに遷移したらプレイヤーを生成する </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void GameSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestScene")
        {
            Instantiate(_fadeOut);
        }
    }

    IEnumerator SceneLoad()
    {
        Instantiate(_fadeIn);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("TestScene");
    }
}
