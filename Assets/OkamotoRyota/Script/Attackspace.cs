using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackspace : MonoBehaviour
{
    [SerializeField]public float AttackInterval = 3;
    public float AttackIntervalMin = 0.2f;
    float _timer = 0;
    // Update is called once per frame
    void Update()
    {

        _timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _timer > AttackInterval)
        {
            AttackIntervalMin = 0;
        }
    }
}
