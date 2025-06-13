using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrier : MonoBehaviour, IIntereactable
{
    [SerializeField] string interactionTag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Interaction(string objectTag)
    {
        if (interactionTag == objectTag)
        {
            Destroy(gameObject);
        }
    }
}
