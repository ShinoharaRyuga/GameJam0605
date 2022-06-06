using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attackspace : MonoBehaviour
{
    [SerializeField] Slider _coolTimeSlider = default;
    [SerializeField]public float AttackInterval = 3;
    public float AttackIntervalMin = 0.2f;
    public float _timer = 0;

    private void Start()
    {
        _coolTimeSlider.maxValue = AttackInterval;
    }
    void Update()
    {
        _coolTimeSlider.value = _timer;
        _timer += Time.deltaTime;
    }
}
