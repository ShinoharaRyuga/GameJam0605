using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int HP;//playersHP
    public int HPmax = 3;//PlayerMAXHP = 3
    void Start()
    {
        HP = HPmax;//�ŏ���player��HP��max�̏�Ԃɂ���

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamage(int _damage)//�_���[�W���󂯂��ꍇ�Ɏ��s�����鏈��
    {
        HP -= _damage;
        if(HP <= 0)
        {
            HP = 0;//����HP���_���[�W���󂯁AHP��0�ȉ��ɂȂ����ꍇ0�ɂ���
        }
    }
}
