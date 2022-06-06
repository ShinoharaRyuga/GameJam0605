using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   // [SerializeField] LayerMask _layerMask = default;
    [SerializeField] float _rayDistance = 100f;
    [SerializeField] int _atk = 1;
    Attackspace _attackCoolTime;

    void Start()
    {
        _attackCoolTime = GetComponent<Attackspace>();
    }

    void Update()
    { 
        if(Input.GetButtonDown("Fire1") && _attackCoolTime._timer > _attackCoolTime.AttackInterval)
        {
            Shot();
        }
    }

    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit)
        {
            if (hit.collider.gameObject.CompareTag("HealItem"))
            {
                var item = hit.collider.GetComponent<HealItem>();
                item.GetHealItem();
                Debug.Log($"�񕜃A�C�e���ɓ�������");
            }
            else if (hit.collider.gameObject.CompareTag("SpeedUpItem"))
            {
                Debug.Log("���x�A�b�v�A�C�e���ɓ�������");
                var item = hit.collider.GetComponent<SpeedUpItem>();
                item.GetSpeedUpItem();
            }
            else if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                var enemy = hit.collider.GetComponent<Enemy>();
                Debug.Log("Enemy�ɓ�������");
                enemy.GetDamage(_atk);
            }
        }
        else if (hit.collider == null)
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }
    }
}
