using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance : MonoBehaviour
{
    public enum OBJECT_STATE
    {
        PRESSED,
        OVER,
        STANDBY
    }

    [SerializeField] private int m_powerConsumed;
    bool isOn = false;
    [SerializeField] Color COLOR_PRESSED = Color.red;
    [SerializeField] Color COLOR_MOUSEOVER = Color.green;
    Color m_Original;
    private OBJECT_STATE m_currentState;
    SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        m_currentState = OBJECT_STATE.STANDBY;
        m_spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        m_Original = m_spriteRenderer.color;
    }

    void Update()
    {
        PowerUsage();
    }

    void PowerUsage()
    {
        if (isOn)
        {
            ScoreManager.GetInstance().AddPowerUsage(m_powerConsumed);
        }
    }

    public void TurnOn()
    {
        isOn = !isOn;
        ApplianceColor();
        Debug.Log(this.gameObject.name + "Is On is" + isOn);
    }

    public void TurnOn(bool p_isOn)
    {
        isOn = p_isOn;
        ApplianceColor();
        Debug.Log(this.gameObject.name + "Is On is" + isOn);
    }

    public void ApplianceColor()
    {
        if (!isOn)
        {
            SetPressedColor(OBJECT_STATE.STANDBY);
        }
        else
        {
            SetPressedColor(OBJECT_STATE.PRESSED);
        }
    }

    public void SetPressedColor(OBJECT_STATE p_state)
    {
        switch (p_state)
        {
            case OBJECT_STATE.PRESSED:
                m_spriteRenderer.color = COLOR_PRESSED;
                break;
            //case OBJECT_STATE.OVER:
            //    m_spriteRenderer.color = COLOR_MOUSEOVER;
            //    break;
            case OBJECT_STATE.STANDBY:
                m_spriteRenderer.color = m_Original;
                break;
            default:
                break;
        }
    }

}