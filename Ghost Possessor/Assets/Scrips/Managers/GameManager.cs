using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController2 possessable;

    public GameObject canvas;
    private Transform targetTransform = null;
    private string currentLoadedSceneName = null;
    [SerializeField] private SceneReferences main = null;


    private void OnEnable()
    {
        SceneReferences.onLoaded += HandleSceneReferencesLoaded;
        Portal.onPortalToSceneEnter += HandlePortalSceneEntry;
        Portal.onPortalToMainEnter += HandlePortalToMainEnter;
        PlayerController2.onPlayerCreated += HandlePlayerCreated;
    }
    private void OnDisable()
    {
        SceneReferences.onLoaded -= HandleSceneReferencesLoaded;
        Portal.onPortalToSceneEnter -= HandlePortalSceneEntry;
        Portal.onPortalToMainEnter -= HandlePortalToMainEnter;
        PlayerController2.onPlayerCreated += HandlePlayerCreated;

    }
    private void HandleSceneReferencesLoaded(SceneReferences scene)
    {
        if (main == null)
        {
            main = scene;
        }
    }

    public void SingleLoading()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
    public void LoadScene(string targetScene)
    {
        SceneLoader.Instance.LoadSceneWithFakeLoading(targetScene);
    }

    private void HandlePortalSceneEntry(GameObject go, string sceneName, Transform targetTransform)
    {
        if (go.CompareTag("possess"))
        {
            SceneLoader.onLoadingCompleted += HandleSceneLoadingComplete;
            SceneLoader.Instance.LoadSceneWithFakeLoading(sceneName);
            currentLoadedSceneName = sceneName;
            this.targetTransform = targetTransform;
        }
    }

    private void HandlePortalToMainEnter(GameObject go, Transform targetTransform)
    {
        Debug.Log(go + " " + targetTransform);
        if (go.CompareTag("possess"))
        {

            possessable.transform.position = targetTransform.position;
            possessable.transform.rotation = targetTransform.rotation;
            main.SetActiveGo(true);
            SceneManager.UnloadSceneAsync(currentLoadedSceneName);
        }
    }

    private void HandleSceneLoadingComplete()
    {
        main.SetActiveGo(false);
        possessable.transform.position = targetTransform.position;
        possessable.transform.rotation = targetTransform.rotation;
        SceneLoader.onLoadingCompleted -= HandleSceneLoadingComplete;

    }

    private void HandlePlayerCreated(PlayerController2 player)
    {
        this.possessable = player;
    }
}
