using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartControll : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("BattleScene");
        Debug.Log("スタートボタンを押した");
    }
}
