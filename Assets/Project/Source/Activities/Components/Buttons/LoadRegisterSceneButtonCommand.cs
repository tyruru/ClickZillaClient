using UnityEngine.SceneManagement;

public class LoadRegisterSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneController.LoadAndCloseScene(SceneNames.RegisterScene, gameObject.scene.name);
    }
}
