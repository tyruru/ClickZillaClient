using UnityEngine.SceneManagement;

public class LoadLeaderboardSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneManager.LoadScene(SceneNames.LeaderboardScene, LoadSceneMode.Additive);
    }
}
