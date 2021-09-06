using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFunction : MonoBehaviour
{
    [SerializeField] Appliance[] Appliances;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Boy")
        {
            ApplianceOn();
        }
    }

    void ApplianceOn()
    {
        foreach (var item in Appliances)
        {
            item.TurnOn(p_isOn: true);
        }
    }

}