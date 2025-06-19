using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessObject : MonoBehaviour
{
    [Header("Movement")] public Rigidbody rb;
    [SerializeField] private float maxAngleMovement = 30f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Camera")]
    public Transform pivot;
    public GameObject cameraObj;
    public Transform cameraTransform;

    [Header("Rotation")][SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float maxAngle = 45f;
    private float rotationY = 0f;
    private float rotationX = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Ability() 
    {
        Debug.Log("Base class, no ability");
    
    }
    
}
