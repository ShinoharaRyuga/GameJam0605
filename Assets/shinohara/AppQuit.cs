using UnityEngine;

/// <summary>�G�X�P�[�v�L�[����������A�v���𗎂Ƃ� </summary>
public class AppQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
