using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighting : MonoBehaviour
{
    private RaycastHit2D m_Press;
    private GameObject m_Object;
    [SerializeField] bool m_On = true;
    public static int m_NoOfLitRooms = 0;
    void Start()
    {
    }
    void Update()
    {
        m_Press = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        SwitchLight();
    }
    private void SwitchLight()
    {
        if (Input.GetMouseButtonUp(0))
        {
            try
            {
                if (m_Press.collider.gameObject.tag == "Panel")
                {

                    bool isLightOn = m_Press.collider.gameObject.GetComponent<Image>().enabled;
                    m_Press.collider.gameObject.GetComponent<Image>().enabled = !isLightOn;
                    if (isLightOn)
                    {
                        m_NoOfLitRooms = 1 + m_NoOfLitRooms;
                    }
                    else
                    {
                        m_NoOfLitRooms = m_NoOfLitRooms - 1;
                    }
                }

                else
                {
                    Debug.Log("Wrong Object Pressed");
                }
            }
            catch
            {
                Debug.Log("Wrong Object Pressed");
            }
        }

    }
}