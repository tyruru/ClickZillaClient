using Zenject;

public class LoadAuthorizeSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneController.LoadAndCloseScene(SceneNames.AuthorizeScene, gameObject.scene.name); 
    }
}
