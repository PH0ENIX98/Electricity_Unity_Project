using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance : MonoBehaviour
{
    [SerializeField] private int m_powerConsumed;
    bool isOn = false;
    [SerializeField] Color m_Pressed;

    void Update()
    {
        PowerUsage();
    }

    private void OnMouseDown()
    {
        isOn = !isOn;
    }

    void PowerUsage()
    {
        if (isOn)
        {
            ScoreManager.GetInstance().AddPowerUsage(m_powerConsumed);
        }
        //else
        //{
        //    ScoreManager.GetInstance().DecreasePowerUsage(m_powerConsumed);
        //}
    }
}