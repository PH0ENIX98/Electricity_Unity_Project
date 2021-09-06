using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private RaycastHit2D m_ApplianceHit;

    void FixedUpdate()
    {

        //if (m_ApplianceHit.collider != null)
        //{
        //    if (m_ApplianceHit.collider.gameObject.tag == "Appliance")
        //    {
        //        m_ApplianceHit.collider.gameObject.GetComponent<Appliance>().GetPressedColor(Appliance.OBJECT_STATE.OVER);
        //    }
        //    if (m_ApplianceHit.collider.gameObject.tag != "Appliance")
        //    {
        //        Debug.Log("Not an Appliance");
        //    }
        //}


        if (Input.GetMouseButtonDown(0))
        {
            m_ApplianceHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (m_ApplianceHit.collider != null)
            {
                if (m_ApplianceHit.collider.gameObject.tag == "Appliance")
                {
                    m_ApplianceHit.collider.gameObject.GetComponent<Appliance>().TurnOn();
                }
            }
        }
    }
}