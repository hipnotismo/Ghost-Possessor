using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    private bool isPause = false;
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    public static event Action<bool> onPausePress;

    private void OnEnable()
    {
        GameplayMenu.onKeepPlayingPress += HandleReturnFromMenu;
    }

    void Update()
    {
        if (Input.GetKeyUp(pauseKey))
        {
            isPause = !isPause;
            onPausePress?.Invoke(isPause);
        }
    }

    private void HandleReturnFromMenu()
    {
        isPause = !isPause;
        onPausePress?.Invoke(isPause);
    }
}
