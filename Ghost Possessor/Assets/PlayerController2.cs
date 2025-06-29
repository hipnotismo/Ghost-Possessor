using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public static event Action<PlayerController2> onPlayerCreated;

    public GameObject pivot;
    public GameObject cameraTransform;

    [Header("Movement")] 
    private Rigidbody rb;
    [SerializeField] private float maxAngleMovement = 30f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Rotation")][SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float maxAngle = 45f;
    private float rotationY = 0f;
    private float rotationX = 0f;
    [SerializeField] private KeyCode shootKey = KeyCode.Q;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        onPlayerCreated?.Invoke(this);
    }


    private void Update()
    {
        HandleRotation();
        HandleMovement();
        if (Input.GetKeyDown(shootKey))
        {
            HandlePossession();
        }
       
    }
    private void HandlePossession()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            Debug.Log("Ray hits something");
            if (hit.collider.CompareTag("possess") )
            {
                Debug.Log("Trying to posses");

                GameObject newPossessable = hit.collider.gameObject;
                if (newPossessable.TryGetComponent(out PlayerController2 rb))
                {
                    Debug.Log(newPossessable.gameObject.name + " Already has a controller");

                }
                else
                {
                    Debug.Log("Putting new controller");

                    PlayerController2 newController = newPossessable.GetComponent<PlayerController2>();

                    newController = newPossessable.AddComponent<PlayerController2>();

                    Transform newCameraPivot = newController.transform;
                    pivot.transform.SetParent(newCameraPivot);

                    pivot.transform.localPosition = new Vector3(0, 0.638f, -1.667f);
                    pivot.transform.localRotation = Quaternion.identity;

                    newController.pivot = pivot;
                    newController.cameraTransform = cameraTransform;

                    PlayerController2 oldController = this.GetComponent<PlayerController2>();
                    Destroy(oldController);
                }
               
            }
        }
    }
    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationY += mouseX;
        pivot.transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxAngle, maxAngle);

        cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0f);
        transform.rotation = Quaternion.Euler(0, rotationY, 0f);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 moveDir = (camForward * vertical + camRight * horizontal).normalized;
        Vector3 velocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.z * moveSpeed);

        if (CanMove(moveDir))
            rb.velocity = velocity;
    }

    private bool CanMove(Vector3 moveDir)
    {
        Terrain terrain = Terrain.activeTerrain;
        Vector3 relativePos = GetMapPos();
        Vector3 normal = terrain.terrainData.GetInterpolatedNormal(relativePos.x, relativePos.z);
        float angle = Vector3.Angle(normal, Vector3.up);

        float currentHeight = terrain.SampleHeight(rb.position);
        float nextHeight = terrain.SampleHeight(rb.position + moveDir * 5);


        if (angle > maxAngleMovement && nextHeight > currentHeight)
            return false;
        return true;
    }

    private Vector3 GetMapPos()
    {
        Vector3 pos = rb.position;
        Terrain terrain = Terrain.activeTerrain;

        return new Vector3((pos.x - terrain.transform.position.x) / terrain.terrainData.size.x,
                           0,
                           (pos.z - terrain.transform.position.z) / terrain.terrainData.size.z);
    }
}

