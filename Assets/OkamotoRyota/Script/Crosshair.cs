using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour

{
    [SerializeField]private GameObject m_object = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 touchScreenPosition = Input.mousePosition;


        touchScreenPosition.z = 10.0f;

        Camera gameCamera = Camera.main;
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);
        Vector3 pos = new Vector3(touchWorldPosition.x, touchWorldPosition.y, 0);
        m_object.transform.position = touchWorldPosition;

    }
}
