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
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log($"{sceneName}�V�[�������[�h");
    }
}
