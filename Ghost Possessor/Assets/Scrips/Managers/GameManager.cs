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
            Debug.Log("The position gived by the portla is: " + targetTransform.transform.position + "and the position store by the game manager is: "+ this.targetTransform.transform.position);
        }
    }

    private void HandlePortalToMainEnter(GameObject go, Transform targetTransform)
    {
        if (go.CompareTag("possess"))
        {
            Debug.Log("The possition gived is: " + targetTransform.transform.position);

            possessable.transform.position = targetTransform.position;
            possessable.transform.rotation = targetTransform.rotation;
            Debug.Log("The new possition  is: " + possessable.transform.position);

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
