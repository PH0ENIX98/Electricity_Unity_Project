using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    private RaycastHit2D m_Press;

    void Update()
    {
        m_Press = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        LightOnFunction();
        LightOffFunction();
    }

    void LightOffFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Press.collider.gameObject.SetActive(true);
        }
    }

    void LightOnFunction()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_Press.collider.gameObject.SetActive(false);
        }

    }
}
