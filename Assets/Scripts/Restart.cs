using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    float prevSpeed;
    [SerializeField] Animator Run;
   
    private void Start()
    {
        prevSpeed = Run.speed;
    }
    void Update()
    {
        AnimatorSpeed();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void AnimatorSpeed()
    {
        if (Time.timeScale == 1)
        {
            Run.speed = prevSpeed;
        }
        else
        {
            Run.speed = 0;
        }
    }
}