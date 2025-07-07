using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrier : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionTag;
   
    public void Interaction(string objectTag)
    {
        if (interactionTag == objectTag)
        {
            Destroy(gameObject);
        }
    }
}
