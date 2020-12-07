using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadByIndex(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadCurrent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNext()
    {
        int next = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(next + 1);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(0);
    }
}
