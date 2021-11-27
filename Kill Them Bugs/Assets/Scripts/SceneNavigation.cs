using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/// <summary>
/// Author: Jamie Carmichael
/// Details: THis script allow for quiting the game and navigating between scenes.
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Objects/Scene Navigation")]
public class SceneNavigation : ScriptableObject
{
    public void ChangeScene(string nameOfScene)
    {
        SceneManager.LoadSceneAsync(nameOfScene,LoadSceneMode.Single);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetCheckpoint()
    {
        PlayerPrefs.SetInt("LastCheckpoint", 0);
    }
}
