using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void WinCondition()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseCondition()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
