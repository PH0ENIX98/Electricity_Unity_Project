using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
   public void StartGame()
    {
        Time.timeScale = 1;
    }
}
