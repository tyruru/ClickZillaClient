using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void LoadAndCloseScene(string sceneName, string sceneForClosing)
    {
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadOp.completed += (op) =>
        {
            Scene loadedScene = SceneManager.GetSceneByName(sceneName);

            if (loadedScene.IsValid())
            {
                SceneManager.SetActiveScene(loadedScene);
            }

            SceneManager.UnloadSceneAsync(sceneForClosing);
        };
    }
}
