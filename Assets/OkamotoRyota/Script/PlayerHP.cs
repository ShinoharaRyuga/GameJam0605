using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int HP;//playersHP
    public int HPmax = 3;//PlayerMAXHP = 3
    [Tooltip("Slider"), SerializeField] Slider _hpSlider = default;
    [Tooltip("InfoText �ɕ\������ Text")] UI _uiText;

    void Start()
    {
        HP = HPmax;//�ŏ���player��HP��max�̏�Ԃɂ���
        _hpSlider.maxValue = HPmax;
        _hpSlider.value = HPmax;
        _uiText = GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamage(int _damage)//�_���[�W���󂯂��ꍇ�Ɏ��s�����鏈��
    {
        HP -= _damage;
        _uiText._infoText.text = _damage + "�_���[�W�󂯂��I";
        _hpSlider.value -= _damage;
        if(HP <= 0)
        {
            HP = 0;//����HP���_���[�W���󂯁AHP��0�ȉ��ɂȂ����ꍇ0�ɂ���
        }
    }
}
