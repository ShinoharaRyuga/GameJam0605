using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attackspace : MonoBehaviour
{
    [SerializeField] Slider _coolTimeSlider = default;
    [SerializeField]public float AttackInterval = 1;
    public float AttackIntervalMin = 0.2f;
    public float _timer = 0;

    PlayerHP _text;

    private void Start()
    {
        _text = GetComponent<PlayerHP>();
        _coolTimeSlider.maxValue = AttackInterval;
    }
    void Update()
    {
        _coolTimeSlider.value = _timer;
        _timer += Time.deltaTime;
    }

    public void SpeedUp(float speedupvalue)
    {
        AttackInterval -= speedupvalue;
        _text.UiText.text = $"攻撃速度が早くなった";
        if(AttackInterval < AttackIntervalMin)
        {
            _text.UiText.text = "攻撃速度はマックスです";
            return;
        }
    }
}
