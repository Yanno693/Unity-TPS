using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovementScript : MonoBehaviour /// Handle basic player mouvement
{
    public CharacterController characterController;
    public Camera currentCamera;
    
    // Start is called before the first frame update
    public float movementSpeed;
    public float rotationSpeed;

    private readonly Vector2 VEC2_FORWARD = new Vector2(0, 1);

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementSpeed = 5.0f;
        rotationSpeed = 10.0f;

    }

    public static Vector2 Vec2Rotate(Vector2 v, float rad)
    {
        return new Vector2(
            v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
            v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
        );
    }

    // Update is called once per frame
    void Update()
    {
        // Character Motion for roaming camera (no rotation of character for now)

        Vector3 forward = transform.position - currentCamera.transform.position;
        forward.y = 0;
        Vector2 directionForward = new Vector2(forward.x, forward.z).normalized;

        Vector2 directionInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        float angleBetween = Vector2.SignedAngle(VEC2_FORWARD, directionForward) * Mathf.Deg2Rad;
        Vector2 directionRotation = Vec2Rotate(directionInput, angleBetween);

        characterController.Move(new Vector3(directionRotation.x,0,directionRotation.y) * movementSpeed * Time.deltaTime);

        if(directionRotation.magnitude > 0.1) {
            //transform.rotation = Quaternion.LookRotation(new Vector3(directionRotation.x,0,directionRotation.y), Vector3.up);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(new Vector3(directionRotation.x, 0, directionRotation.y)),
                Time.deltaTime * rotationSpeed * ( 
                    Quaternion.Angle(
                         transform.rotation,
                         Quaternion.LookRotation(new Vector3(directionRotation.x, 0, directionRotation.y)
                        )
                    ) * Mathf.Deg2Rad
                )
            );
        }
    }
}
