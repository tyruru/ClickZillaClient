
using UnityEngine.SceneManagement;

public class LoadMainMenuButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneController.LoadAndCloseScene(SceneNames.MainMenu, gameObject.scene.name);
    }
}
