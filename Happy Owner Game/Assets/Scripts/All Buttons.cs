using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllButtons : MonoBehaviour
{
    public int scene;
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
