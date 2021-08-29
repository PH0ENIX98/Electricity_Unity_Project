using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighting : MonoBehaviour
{
    private RaycastHit2D m_Press;
    private GameObject m_Object;
    [SerializeField] bool m_On = true;
   

    void Update()
    {
        m_Press = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        SwitchLight();
    }
    //Con Code
    void SwitchLight()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (m_Press.collider.gameObject.tag == "Panel")
            {
                var isLightOn = m_Press.collider.gameObject.GetComponent<Image>().enabled;
                m_Press.collider.gameObject.GetComponent<Image>().enabled = !isLightOn;

            }
        }
    }

    public GameObject m_SelectedRoom()
    {
        m_Object = m_Press.collider.gameObject;
        return m_Object;
    }
}