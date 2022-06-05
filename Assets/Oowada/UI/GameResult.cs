using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    [SerializeField] Text _resultTime = default;
    [SerializeField] string _titleSceneName = "";

    public void SetResultTime(float time)
    {
        _resultTime.text = time.ToString();
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene(_titleSceneName);
    }
}
