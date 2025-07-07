using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerController possessable;

    public GameObject canvas;
    private Transform targetTransform = null;
    private string currentLoadedSceneName = null;
    [SerializeField] private SceneReferences main = null;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneReferences.onLoaded += HandleSceneReferencesLoaded;
        Portal.onPortalToSceneEnter += HandlePortalSceneEntry;
        Portal.onPortalToMainEnter += HandlePortalToMainEnter;
        PlayerController.onPlayerCreated += HandlePlayerCreated;
    }
    private void OnDisable()
    {
        SceneReferences.onLoaded -= HandleSceneReferencesLoaded;
        Portal.onPortalToSceneEnter -= HandlePortalSceneEntry;
        Portal.onPortalToMainEnter -= HandlePortalToMainEnter;
        PlayerController.onPlayerCreated += HandlePlayerCreated;

    }

    private void HandleSceneReferencesLoaded(SceneReferences scene)
    {
        if (main == null)
        {
            main = scene;
        }
    }

    public void SingleLoading(string targetScene)
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        currentLoadedSceneName = m_Scene.name;
        SceneLoader.onLoadingCompleted += UnloadScene;
        SceneLoader.Instance.LoadSceneWithFakeLoading(targetScene);


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

    private void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(currentLoadedSceneName);
        SceneLoader.onLoadingCompleted -= UnloadScene;

    }

    public void UnloadHouse(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);

    }
    private void HandleSceneLoadingComplete()
    {
        main.SetActiveGo(false);
        possessable.transform.position = targetTransform.position;
        possessable.transform.rotation = targetTransform.rotation;
        SceneLoader.onLoadingCompleted -= HandleSceneLoadingComplete;

    }

    private void HandlePlayerCreated(PlayerController player)
    {
        this.possessable = player;
    }
}
