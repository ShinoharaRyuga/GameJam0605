using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [Tooltip("�_���[�W�̃G�t�F�N�g"), SerializeField] GameObject effectDamege;
    [Tooltip("�G�t�F�N�g�̕\������"), SerializeField] float WaitforTime;
    [SerializeField] int HP;
    public int HPmax = 3;//PlayerMAXHP = 3
    [Tooltip("Slider"), SerializeField] Slider _hpSlider = default;
    [Tooltip("InfoText �ɕ\������ Text"), SerializeField] Text _uiText;
    Animator _damageAnimator => effectDamege.GetComponent<Animator>();
    bool _dieFlag = false;
    public Text UiText { get => _uiText; set => _uiText = value; }
    void Start()
    {
        HP = HPmax;//�ŏ���player��HP��max�̏�Ԃɂ���
        _hpSlider.maxValue = HPmax;
        _hpSlider.value = HP;
    }

    public void OnDamage(int _damage)//�_���[�W���󂯂��ꍇ�Ɏ��s�����鏈��
    {
        HP -= _damage;
        UiText.text = $"{_damage}�_���[�W�󂯂��I".ToString();
        _hpSlider.value -= _damage;
        if (effectDamege != null)
        {
            _damageAnimator.SetTrigger("Damage");
        }
      
        if(HP <= 0 && !_dieFlag) //���S
        {
            HP = 0;//����HP���_���[�W���󂯁AHP��0�ȉ��ɂȂ����ꍇ0�ɂ���
            GameManager.Instance.GameOver();
            _dieFlag = true;
        }
    }

    public void Heal(int healpoints)
    {
        Debug.Log(HP);
        if(HP < HPmax)
        {
            HP += healpoints;
            _hpSlider.value += healpoints;
            UiText.text = $"{healpoints}�񕜂���";
        }
        else if(HP >= HPmax)
        {
            UiText.text = "HP�͊��ɍő�ł�";
            return;
        }
    }

    IEnumerator SetDamageEffect()
    {
        effectDamege.SetActive(true);
        yield return new WaitForSeconds(WaitforTime);
        effectDamege.SetActive(false);
    }
}
