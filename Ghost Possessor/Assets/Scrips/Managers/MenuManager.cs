using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void TurnOnPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void TurnOffPanel(GameObject panel)
    {
        Debug.Log("this");
        panel.SetActive(false);
    }

    public void SceneChange()
    {
        Debug.Log("that");

        GameManager.Instance.SingleLoading("Main Scene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
