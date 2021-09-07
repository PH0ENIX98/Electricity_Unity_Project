using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FactsManager : MonoBehaviour
{
    [SerializeField] GameObject m_FactPanel;
    [SerializeField] Text m_DidYouKnow;
    [SerializeField] string[] Facts;
    int m_stringLength, m_index;

    private void Start()
    {
        m_stringLength = Facts.Length;

        m_index = Random.Range(0, m_stringLength);
        if (Time.timeScale == 0)
        {
            m_DidYouKnow.text = Facts[m_index];
            Debug.Log(m_index);
            m_FactPanel.SetActive(true);
        }
        else
        {
            m_FactPanel.SetActive(false);
        }
    }
   
}