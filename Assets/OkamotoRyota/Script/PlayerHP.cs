using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int HP;//playersHP
    public int HPmax = 3;//PlayerMAXHP = 3

    [Tooltip("Slider"), SerializeField] Slider _hpSlider = default;
    [Tooltip("InfoText に表示する Text"), SerializeField] Text _infoText = default;

    void Start()
    {
        HP = HPmax;//最初にplayerのHPをmaxの状態にする
        _hpSlider.maxValue = HPmax;
        _hpSlider.value = HPmax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamage(int _damage)//ダメージを受けた場合に実行させる処理
    {
        HP -= _damage;
        if(HP <= 0)
        {
            HP = 0;//もしHPがダメージを受け、HPが0以下になった場合0にする
        }
    }
}
