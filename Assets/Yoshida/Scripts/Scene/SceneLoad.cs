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
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log($"{sceneName}シーンをロード");
    }
}
