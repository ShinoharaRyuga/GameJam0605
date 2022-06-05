using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UŒ‚‘¬“x‚ğ‘‚­‚·‚éƒAƒCƒeƒ€‚ÌƒNƒ‰ƒXBPlayer ‚ÌUŒ‚‚ª“–‚½‚Á‚½‚ç Player ‚ÌUŒ‚ŠÔŠu‚ğ’Z‚­‚·‚éB
/// </summary>
public class SpeedUpItem : MonoBehaviour
{
    [Tooltip("‘‚­‚·‚éŠÔŠu"), SerializeField] float _reduceTime = 0.2f;


    public void GetSpeedUpItem()
    {
        var currentspeed = GameManager.Instance.Attackspace.AttackInterval;
        var minspeedvalue = GameManager.Instance.Attackspace.AttackIntervalMin;
        currentspeed -= _reduceTime;

        if(currentspeed < minspeedvalue)
        {
            currentspeed = minspeedvalue;
            Debug.Log("Speed‚ÍÅ‘¬");
        }
    }
}
