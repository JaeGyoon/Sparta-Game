using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnGameStart()
    {
        LoadSceneManager.Instance.SwitchingScene(SceneIndex.GameScene);
    }

    public void OnBtnOption()
    {
        Debug.Log("�ɼ� ��ư ����");
    }

    public void OnBtnQuit()
    {
        Debug.Log("������ ��ư ����");
    }
}
