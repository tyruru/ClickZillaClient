
using UnityEngine.SceneManagement;

public class LoadMainMenuButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
}
