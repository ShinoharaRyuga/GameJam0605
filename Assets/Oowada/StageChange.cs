using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    public void ChangeStage()
    {
        GameManager.Instance.StageChange();
    }
}
