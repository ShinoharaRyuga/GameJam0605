using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackspace : MonoBehaviour
{
    [SerializeField] public float AttackIntervalMin = 0.2f;
    [SerializeField] public float AttackInterval = 3;
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
