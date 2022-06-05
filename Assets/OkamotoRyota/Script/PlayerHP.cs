using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int HP;//playersHP
    public int HPmax = 3;//PlayerMAXHP = 3
    void Start()
    {
        HP = HPmax;//最初にplayerのHPをmaxの状態にする

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
