using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : PossessObject
{
    public override void Ability()
    {
        Debug.Log("test works");
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            // Check if the hit object has the IInteractable interface
            IIntereactable interactable = hit.collider.GetComponent<IIntereactable>();

            if (interactable != null)
            {
                interactable.Interaction("Extinguisher"); // Call the interface method
            }
            else
            {
                Debug.Log("Hit object does not implement IInteractable");
            }
        }
    }
}
