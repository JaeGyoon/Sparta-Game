using UnityEngine.SceneManagement;



public class LoadSceneManager : Singleton<LoadSceneManager>
{    
    public void SwitchingScene(SceneIndex index)
    {
        SceneManager.LoadScene((int)index);
    }
}

public enum SceneIndex
{
    InitScene = 0,
    LobbyScene = 1,
    GameScene = 2,

}