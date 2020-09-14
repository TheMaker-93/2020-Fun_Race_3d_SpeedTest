using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(MonoBehaviour _monoInstance, int _sceneIndex, bool _async)
    {
        Debug.LogWarning("Loading scene number " + _sceneIndex);

        if (_sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            if (_async)
                _monoInstance.StartCoroutine(LoadSceneAsyc(_sceneIndex));
            else
                SceneManager.LoadScene(_sceneIndex);
        }
        else
        {
            Debug.LogError("You are trying to load a scene that is not found on the build settings of the project");
        }

    }


    private static IEnumerator LoadSceneAsyc(int _sceneIndex)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(_sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!sceneLoading.isDone)
        {
            Debug.Log("Loading at " + sceneLoading.progress);

            yield return null;
        }
    }
}
