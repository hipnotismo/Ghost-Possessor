using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static event Action<GameObject, string, Transform> onPortalToSceneEnter;
    public static event Action<GameObject, Transform> onPortalToMainEnter;


    [SerializeField] private string sceneToLoadName;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private bool leadsToMainScene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The position gived by the portal is: " + targetTransform.transform.position);
        if (leadsToMainScene)
        {
            onPortalToMainEnter?.Invoke(other.gameObject, targetTransform);

        }
        else
        {
            onPortalToSceneEnter?.Invoke(other.gameObject, sceneToLoadName, targetTransform);

        }
    }
}
