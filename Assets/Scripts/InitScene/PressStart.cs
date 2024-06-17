using UnityEngine;

public class PressStart : MonoBehaviour
{    
    void Update()
    {
        if (Input.anyKeyDown)
        {          
            LoadSceneManager.Instance.SwitchingScene(SceneIndex.LobbyScene);
        }
    }
}
