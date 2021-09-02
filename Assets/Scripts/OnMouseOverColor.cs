using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverColor : MonoBehaviour
{
    private SpriteRenderer m_SpriteR;
    private Color m_Original, m_Over, m_Pressed;
    private RaycastHit2D m_ApplianceHit;
    void Start()
    {
        m_SpriteR = GetComponentInChildren<SpriteRenderer>();
        m_Original = m_SpriteR.color;
        m_Over = new Color(0, 1, 0);
        m_Pressed = new Color(1, 0, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_ApplianceHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (m_ApplianceHit.collider!= null)
            {
                if (m_ApplianceHit.collider.gameObject.tag == "Appliance")
                {
                    bool m_Red = m_ApplianceHit.collider.gameObject.GetComponent<SpriteRenderer>().color == m_Pressed;
                    if (m_Red)
                    {
                        m_ApplianceHit.collider.gameObject.GetComponent<SpriteRenderer>().color = m_Original;
                    }
                    if (!m_Red)
                    {
                        m_ApplianceHit.collider.gameObject.GetComponent<SpriteRenderer>().color = m_Pressed;
                    }
                }
            }
        }
    }
    private void OnMouseOver()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color != m_Pressed)
        {
           
            gameObject.GetComponent<SpriteRenderer>().color = m_Over;
        }
    }
    private void OnMouseExit()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color != m_Pressed)
        {
            m_SpriteR.color = m_Original;
        }

    }
}
