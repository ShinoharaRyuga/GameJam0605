using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoshidaCrosshair : MonoBehaviour
{
    [SerializeField] GameObject _sprite = default;
    

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Crosshair(); 
    }

    private void Crosshair()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        _sprite.transform.position = pos;
    }
}
