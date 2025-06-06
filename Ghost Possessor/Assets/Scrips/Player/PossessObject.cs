using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessObject : MonoBehaviour
{
    private string possessionTag = "possess";
    private int possesionRange = 1;
    private GameObject possessTarget;
   
    void Update()
    {
        Possession();

       
    }

    public void Possession()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);



        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, possesionRange))
        {
            Debug.DrawRay(transform.position, forward, Color.blue);
            if (hit.transform.CompareTag(possessionTag))
            {
                Debug.Log("Did Hit a valid target");
                possessTarget = hit.transform.gameObject;
            }
            else
            {
                Debug.Log("Did not Hit a valid target");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, forward, Color.red);

            possessTarget = null;

            Debug.Log("Did not Hit");
        }
    }

    public GameObject GetPossessionObject()
    {
        return possessTarget;
    }
}
