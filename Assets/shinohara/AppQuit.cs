using UnityEngine;

/// <summary>エスケープキーを押したらアプリを落とす </summary>
public class AppQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown(""))
        {
            Application.Quit();
        }
    }
}
