using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform pivot;
    public Transform cameraTransform;

    [Header("Movement")] public Rigidbody rb;

    [Header("Object")]
    public GameObject possessedObject;
    public PossessObject currentPossessObject;

    private string possessionTag = "possess";
    private int possesionRange = 1;


    private void Awake()
    {
        rb = possessedObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            HandlePossession();
        if (Input.GetKeyUp(KeyCode.E))
            currentPossessObject.Ability();
        currentPossessObject.HandleMovement();
        currentPossessObject.HandleRotation();
    }
   
   
    public void HandlePossession()
    {
        RaycastHit hit;

        Vector3 forward = possessedObject.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(possessedObject.transform.position, possessedObject.transform.TransformDirection(Vector3.forward), out hit, possesionRange))
        {
            Debug.DrawRay(possessedObject.transform.position, forward, Color.blue);
            if (hit.transform.CompareTag(possessionTag))
            {
                Debug.Log("Did Hit a valid target");
                possessedObject = hit.transform.gameObject;
                rb = possessedObject.GetComponent<Rigidbody>();
                pivot = possessedObject.transform;
                currentPossessObject.TurnOffCamera();
                currentPossessObject = possessedObject.GetComponent<PossessObject>();
                currentPossessObject.TurnOnCamera();

            }
            else
            {
                Debug.Log("Did not Hit a valid target");
            }
        }
        else
        {
            Debug.DrawRay(possessedObject.transform.position, forward, Color.red);


            Debug.Log("Did not Hit");
        }
    }
}

