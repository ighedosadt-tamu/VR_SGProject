using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    private int current_scene = 2;

    public void RestartScene()
    {
        SceneManager.LoadScene(current_scene);
    }

    public void NextScene(int index)
    {
        current_scene = index;
        SceneManager.LoadScene(current_scene);
    }
}
