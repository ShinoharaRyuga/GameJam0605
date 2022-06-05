using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackspace : MonoBehaviour
{
    [SerializeField] float AttackInterval = 3;
    float Timer;
    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && Timer > AttackInterval)
        {
            Timer = 0;
        }
    }
}
