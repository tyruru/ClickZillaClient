using UnityEngine.SceneManagement;

public class LoadRegisterSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneManager.LoadScene(SceneNames.RegisterScene);
    }
}
