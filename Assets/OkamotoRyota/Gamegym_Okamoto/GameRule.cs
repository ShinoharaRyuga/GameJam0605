using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRule : MonoBehaviour
{
    public void ClickGameRuleBotton()
    {
        SceneManager.LoadScene("GameRule");
        Debug.Log("—V‚Ñ•û‚ð‰Ÿ‚µ‚½");
    }
}
