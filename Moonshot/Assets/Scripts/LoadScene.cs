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
}
