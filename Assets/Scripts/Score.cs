using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    private int displayScore=0;
    public Text scoreUI;
    private RaycastHit2D m_ScoreHit;
   

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_ScoreHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            scoreUI.enabled = true;

            if (m_ScoreHit.collider.gameObject.GetComponent<Image>().enabled == false)
            {
                StartCoroutine(ScoreUpdater());
            }

        }

        if (m_ScoreHit.collider.gameObject.GetComponent<Image>().enabled == false)
        {
            StartCoroutine(ScoreUpdater());
        }
    }

    private IEnumerator ScoreUpdater()
    {
        displayScore++;
        scoreUI.text = displayScore.ToString();
        yield return new WaitForSeconds(0.1f);
    }
}