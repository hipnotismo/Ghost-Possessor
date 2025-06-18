using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject canvas;

    public void SetCanvas(GameObject _canvas)
    {
        canvas = _canvas;
    }
    public void LoadScene(string targetScene)
    {
        SceneLoader.Instance.LoadSceneWithFakeLoading(targetScene, canvas);
    }
}
