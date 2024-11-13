using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Used first link in references for this
public class LogicScript : MonoBehaviour
{
    public GameObject winScreen;
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        winScreen.SetActive(true);
    }
}

