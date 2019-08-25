using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement2 : MonoBehaviour // Player movement when fighting (third person shooting camera)
{
    protected CharacterController characterController;
    public Camera currentCamera;

    public float movementSpeed;
    public float rotationSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementSpeed = 5.0f;
        rotationSpeed = 15.0f;

        if(!currentCamera)
        {
            Camera[] cameraList = FindObjectsOfType<Camera>();
            if(cameraList.Length > 0)
                currentCamera = cameraList[0];
        }
    }

    public static Vector2 Vec2Rotate(Vector2 v, float rad)
    {
        return new Vector2(
            v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
            v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
        );
    }

    void Update()
    {
        float finalSpeed = movementSpeed;

        if (Input.GetButton("Run"))
            finalSpeed *= 2.0f;

        Vector3 forward = transform.position - currentCamera.transform.position;
        forward.y = 0;
        Vector2 directionForward = new Vector2(forward.x, forward.z).normalized;

        Vector2 directionInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        float angleBetween = Vector2.SignedAngle(Vector2.up, directionForward) * Mathf.Deg2Rad;
        Vector2 directionRotation = Vec2Rotate(directionInput, angleBetween);

        characterController.Move(new Vector3(directionRotation.x, 0, directionRotation.y) * finalSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(new Vector3(directionForward.x, 0, directionForward.y)),
            Time.deltaTime * rotationSpeed
        );
    }
}
