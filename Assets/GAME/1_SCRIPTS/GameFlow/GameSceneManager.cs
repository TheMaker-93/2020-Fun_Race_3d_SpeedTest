using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneLoader.LoadScene(this, currentIndex, false);
    }

    public void LoadNextScene()
    {
        Debug.LogWarning("Current scene name is  " + SceneManager.GetActiveScene().name);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.LogWarning("Current " + currentIndex);
        int indexToLoad = currentIndex += 1;
        Debug.LogWarning("next " + indexToLoad);

        SceneLoader.LoadScene(this, indexToLoad, true);
    }

    private void Update()
    {
        // reload current scene
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReloadScene();
        }
    }
}
