using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Transform[] m_spawnPoints = new Transform[6];
    int m_currentIndex = 0;
    [SerializeField] float m_waitingTime=5f;
    [SerializeField] bool isWaiting;

    private void Start()
    {
        isWaiting = false;
    }

    void Update()
    {
        if (!isWaiting && Time.timeScale == 1)
            StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition()
    {
        isWaiting = true;
        ChangeCharacterPosition();
        yield return new WaitForSeconds(m_waitingTime);
        isWaiting = false;
    }

    void ChangeCharacterPosition()
    {

        this.gameObject.transform.position = m_spawnPoints[m_currentIndex].position;
        m_currentIndex++;
        if (m_currentIndex >= m_spawnPoints.Length)
            m_currentIndex = 0;
    }
}
