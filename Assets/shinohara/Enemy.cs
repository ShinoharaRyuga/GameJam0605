using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [SerializeField, Tooltip("体力")] int _hp = 1;
    [SerializeField, Tooltip("移動速度")] float _moveSpeed = 1f;
    [SerializeField, Tooltip("攻撃間隔")] float _attackInterval = 1f;
    [SerializeField, Tooltip("攻撃ダメージ")] int _attackDamage= 1;
    [SerializeField] float _attackFirstDelay = 2.0f;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _deathSound;
    [SerializeField] AudioClip[] _attackSound;
    [SerializeField] GameObject _deathEffect;

    Rigidbody2D _rb2D => GetComponent<Rigidbody2D>();

    void Start()
    {
        var index = Random.Range(0, 8);
        Move((MoveDirection)index);
        StartCoroutine(FirstDelay());
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>ダメージを受ける　体力が0以下になったら削除される </summary>
    /// <param name="damage">受けるダメージ</param>
    public void GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            _audioSource.PlayOneShot(_deathSound);
            Instantiate(_deathEffect, this.transform.position, _deathEffect.transform.rotation);
            Destroy(gameObject);
            GameManager.Instance.ChangeEnemyCount();
        }
    }

    public IEnumerator FirstDelay()
    {
        yield return new WaitForSeconds(_attackFirstDelay);
        yield return Attack();
    }

    /// <summary>一定時間経過したらプレイヤーにダメージを与える </summary>
    /// <returns></returns>
    public IEnumerator Attack()
    {
        while (true)
        {
            //ダメージを与える
            int random = Random.Range(0, _attackSound.Length);
            _audioSource.PlayOneShot(_attackSound[random]);
            GameManager.Instance.PlayerHP.OnDamage(_attackDamage);
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
