using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask = default;
    [SerializeField] float _rayDistance = 100f;

    void Start()
    {
        
    }

    void Update()
    { 
        if(Input.GetButtonDown("Fire1"))
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
            Debug.Log($"{hit}‚É“–‚½‚Á‚½");
        }
        else
        {
            Debug.Log("‰½‚É‚à“–‚½‚ç‚È‚©‚Á‚½");
        }
    }
}
