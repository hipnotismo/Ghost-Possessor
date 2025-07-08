using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public static event Action onKeepPlayingPress;

    private void OnEnable()
    {
        PlayerPause.onPausePress += HandlePause;
    }
    private void OnDisable()
    {
        PlayerPause.onPausePress -= HandlePause;
    }
    private void HandlePause(bool state)
    {
        pauseCanvas.SetActive(state);

        if (state == true) 
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }
    }

    public void KeepPlaying()
    {
        onKeepPlayingPress?.Invoke();
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
