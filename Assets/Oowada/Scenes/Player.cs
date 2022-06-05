using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject m_object = null;

    private void Update()
    {
        Vector3 touchScreenPosition = Input.mousePosition;


        touchScreenPosition.z = 10.0f;

        Camera gameCamera = Camera.main;
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);

        m_object.transform.position = touchWorldPosition;

    }
}
