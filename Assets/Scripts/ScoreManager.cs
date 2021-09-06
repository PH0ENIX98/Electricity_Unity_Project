using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance;
    [Header("Values")]
    private float m_displayScore = 0;

    [Header("UI Objects")]
    [SerializeField] Text scoreUI;
    [SerializeField] Text m_amtUI;
    [SerializeField] private Text m_ButtonText;
    [SerializeField] private Text m_FinishText;
    [SerializeField] Image m_RestartPanel;
    [SerializeField] private Button m_Restart;
    [SerializeField] Color m_Pressed;
    float m_timeValue = 60;
    
    double m_totalAmount;
    double m_powerRate;
    double m_powerDecrease;

    public static ScoreManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        m_RestartPanel.gameObject.GetComponent<Image>().enabled = false;
        m_Restart.gameObject.GetComponent<Image>().enabled = false;
        m_ButtonText.enabled = false;
        m_FinishText.enabled = false;
    }

    void FixedUpdate()
    {
        if (m_timeValue > 0)
        {
            if (m_powerRate > 0)
            {
                m_displayScore = (float)m_powerRate * Time.deltaTime;
                m_totalAmount = m_powerRate * 0.23 * Time.deltaTime;
            }
            scoreUI.text = m_displayScore.ToString("0.00") + "W";
            m_amtUI.text = m_totalAmount.ToString("0.00") + " AED";
            m_timeValue -= Time.deltaTime;
        }

        else
        {
            m_timeValue = 0;
            RestartPanel();
        }
    }

    public float GetDisplayScore()
    {
        return m_displayScore;
    }

    public void AddPowerUsage(int p_powerConsumed)
    {
        if (m_timeValue > 0 && Time.timeScale==1)
        {
            m_powerRate += p_powerConsumed;
        }
    }

    //public void DecreasePowerUsage(int p_powerConsumed)
    //{
    //    m_powerRate -= p_powerConsumed;
    //}

    void RestartPanel()
    {
        m_FinishText.enabled = true;
        if(m_totalAmount<200)
        {  
            m_FinishText.text = "Your bill is " + m_totalAmount.ToString("0.00") + ". You Win!";
        }
        if (m_totalAmount > 200)
        {
            m_FinishText.text = "Your bill is " + m_totalAmount.ToString("0.00") + ". You have failed to limit your bill!";
        }
        m_RestartPanel.GetComponent<Image>().enabled = true;
        m_Restart.GetComponent<Image>().enabled = true;
        m_ButtonText.enabled = true;
    }

    public IEnumerator ResetScore()
    {
        yield return null;
    }
}