using UnityEngine.SceneManagement;

public class LoadAuthorizeSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneManager.LoadScene(SceneNames.AuthorizeScene); 
    }
}
