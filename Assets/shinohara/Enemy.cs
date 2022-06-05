using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [SerializeField, Tooltip("体力")] int _hp = 1;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _attackInterval = 1f;

    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();

    void Start()
    {
        var index = Random.Range(0, 8);
        Move((MoveDirection)index);
        StartCoroutine(Attack());
    }

    /// <summary>ダメージを受ける　体力が0以下になったら削除される </summary>
    /// <param name="damage">受けるダメージ</param>
    public void GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>一定時間経過したらプレイヤーにダメージを与える </summary>
    /// <returns></returns>
    public IEnumerator Attack()
    {
        while (true)
        {
            //ダメージを与える
            yield return new WaitForSeconds(_attackInterval);
        }
    }

    /// <summary>生成されたときに飛ぶ方向を決める </summary>
    /// <param name="direction">飛ぶ方向</param>
    private void Move(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                _rb2D.AddForce(Vector2.up * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.UpperRight:
                _rb2D.AddForce(new Vector2(1, 1).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.Right:
                _rb2D.AddForce(new Vector2(1, 0).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.BottomRight:
                _rb2D.AddForce(new Vector2(1, -1).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.Down:
                _rb2D.AddForce(new Vector2(0, -1).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.BottomLeft:
                _rb2D.AddForce(new Vector2(-1, -1).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.Left:
                _rb2D.AddForce(new Vector2(-1, 0).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;
            case MoveDirection.UpperLeft:
                _rb2D.AddForce(new Vector2(-1, 1).normalized * _moveSpeed, ForceMode2D.Impulse);
                break;

        }
    }
}

/// <summary>飛ぶ方向 </summary>
public enum MoveDirection
{
    Up = 0,             //上
    UpperRight = 1,     //右上
    Right = 2,          //右
    BottomRight = 3,    //右下
    Down = 4,           //下
    BottomLeft = 5,     //?左下
    Left = 6,           //?左
    UpperLeft = 7,      //?左上
}
