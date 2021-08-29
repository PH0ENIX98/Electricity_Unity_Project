using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    private int displayScore = 0;
    private static int m_multiplier;
    public Text scoreUI;
    public Text m_amtUI;
    [SerializeField] private Text m_ButtonText;
    private RaycastHit2D m_ScoreHit;
    private double m_amt;
    [SerializeField] Image m_amtPanel;
    [SerializeField] private Button m_Restart;
    [SerializeField] private Lighting m_RoomNo;

    void Start()
    {

        m_amtPanel.gameObject.GetComponent<Image>().enabled = false;
        m_amtUI.enabled = false;
        m_Restart.gameObject.GetComponent<Image>().enabled = false;
        m_ButtonText.enabled = false;

    }
    void Update()
    {
        m_ScoreHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //var m_room = m_ScoreHit.collider.gameObject.GetComponent<Image>().enabled;
        if (Input.GetMouseButtonUp(0))
        {
           
            scoreUI.enabled = true;
            if (m_ScoreHit.collider != null)
            {
               var m_room = m_ScoreHit.collider.gameObject.GetComponent<Image>().enabled;

                if (m_room == false && Time.timeSinceLevelLoad <= 15f)
                {
                    StartCoroutine(ScoreUpdater());
                }
            }
        }
        if (m_ScoreHit.collider != null)
        {
            var m_room1 = m_ScoreHit.collider.gameObject.GetComponent<Image>().enabled;
            if (m_multiplier!=0 && Time.timeSinceLevelLoad <= 15f)
            {
                StartCoroutine(ScoreUpdater());
            }
            else if (Time.timeSinceLevelLoad >= 15f)
            {
                Amount();
            }
        }
        mult();
    }

    public IEnumerator ScoreUpdater()
    {
        displayScore=displayScore+m_multiplier;
        scoreUI.text = displayScore.ToString() + "W";
        yield return new WaitForSeconds(0.3f);
        m_amt = displayScore * 0.2;
        m_amtUI.text = m_amt.ToString() + " AED is your electricity bill";
    }

    void Amount()
    {
        m_amtPanel.GetComponent<Image>().enabled = true;
        m_amtUI.enabled = true;
        m_Restart.GetComponent<Image>().enabled = true;
        m_ButtonText.enabled = true;
    }

    public void mult()
    {
        m_multiplier = Lighting.m_NoOfLitRooms;
    }

}