using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float m_timeValue = 60;
    [SerializeField] Text m_timerText;

    void Start()
    {
        
    }

    void Update()
    {
        if(m_timeValue>0)
        {
            m_timeValue -= Time.deltaTime;
        }
        else
        {
            m_timeValue = 0;
        }
        DisplayTime(m_timeValue);
    }
   
    void DisplayTime(float p_timetoDisplay)
    {
        if(p_timetoDisplay<0)
        {
            p_timetoDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(p_timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(p_timetoDisplay % 60);

        m_timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
