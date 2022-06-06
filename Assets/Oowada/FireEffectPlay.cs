using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectPlay : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _fireSound;
    [SerializeField] GameObject _fireEffect;

    public void Fire(Vector3 pos)
    {
        int random = Random.Range(0, _fireSound.Length);
        _audioSource.PlayOneShot(_fireSound[random]);
        Instantiate(_fireEffect, pos, Quaternion.identity);
    }

}
