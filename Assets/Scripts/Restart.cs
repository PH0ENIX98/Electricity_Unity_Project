using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    public static int m_Power;
    [SerializeField] private Score m_PowerWatt;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Score()
    {
        //m_Power = m_PowerWatt;
    }

}