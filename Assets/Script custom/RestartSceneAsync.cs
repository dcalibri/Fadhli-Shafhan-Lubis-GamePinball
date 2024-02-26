using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneAsync : MonoBehaviour
{
    // Method to restart the current scene asynchronously
    public void RestartScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    // Coroutine to asynchronously load the scene
    private IEnumerator LoadSceneAsync()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Asynchronously unload the current scene
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(currentSceneIndex);
        yield return unloadOperation;

        // Asynchronously load the current scene again
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(currentSceneIndex, LoadSceneMode.Single);

        // Wait until the load operation is complete
        while (!loadOperation.isDone)
        {
            // You can display a loading progress bar here if needed
            yield return null;
        }
    }
}
