using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
        SceneManager.LoadScene(SceneNames.AudioScene, LoadSceneMode.Additive);
    }
}
