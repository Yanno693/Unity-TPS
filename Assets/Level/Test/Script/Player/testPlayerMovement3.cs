using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovement3 : MonoBehaviour
{
    public Camera currentCamera;

    public float movementSpeed;

    public float rotationSpeed;

    protected MyEnum.PlayerCameraMode playerCameraMode;
    
    protected CharacterController characterController;

    public Cinemachine.CinemachineFreeLook cinemachineRoamingCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementSpeed = 5.0f;
        rotationSpeed = 5.0f;

        if(!currentCamera)
        {
            Camera[] cameraList = FindObjectsOfType<Camera>();
            if(cameraList.Length > 0)
                currentCamera = cameraList[0];
        }

        playerCameraMode = MyEnum.PlayerCameraMode.Roaming;
    }

    public static Vector2 Vec2Rotate(Vector2 v, float rad)
    {
        return new Vector2(
            v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
            v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
        );
    }

    private void RoamingMovement()
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

        characterController.Move(new Vector3(directionRotation.x,0,directionRotation.y) * finalSpeed * Time.deltaTime);

        if(directionRotation.magnitude > 0.1) {
            //transform.rotation = Quaternion.LookRotation(new Vector3(directionRotation.x,0,directionRotation.y), Vector3.up);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(new Vector3(directionRotation.x, 0, directionRotation.y)),
                Time.deltaTime * rotationSpeed * Mathf.Max(0.8f,( 
                    Quaternion.Angle(
                         transform.rotation,
                         Quaternion.LookRotation(new Vector3(directionRotation.x, 0, directionRotation.y)
                        )
                    ) * Mathf.Deg2Rad
                ))
            );
        }
    }

    private void FightingMovement()
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

    void Update()
    {

        
        if(playerCameraMode == MyEnum.PlayerCameraMode.Roaming)
        {   
            RoamingMovement();
        }
        else
        {
            FightingMovement();
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            // Code From Gregoryl - Unity Forums
            if(playerCameraMode == MyEnum.PlayerCameraMode.Roaming)
            {
                playerCameraMode = MyEnum.PlayerCameraMode.Fight;

                cinemachineRoamingCamera.m_XAxis.m_AccelTime = 0f;
                cinemachineRoamingCamera.m_XAxis.m_DecelTime = 0f;

                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.x = 0f;
                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.y = 0f;
                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.z = 0f;

                cinemachineRoamingCamera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.x = 0f;
                cinemachineRoamingCamera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.y = 0f;

                Vector3 offset = cinemachineRoamingCamera.State.RawPosition - cinemachineRoamingCamera.Follow.position;
                offset.y = 0;
                float value = Vector3.SignedAngle(Vector3.back, offset, Vector3.up);
                cinemachineRoamingCamera.m_BindingMode = Cinemachine.CinemachineTransposer.BindingMode.WorldSpace;
                cinemachineRoamingCamera.UpdateCameraState(Vector3.up, -1);
                cinemachineRoamingCamera.m_XAxis.Value = value;
                cinemachineRoamingCamera.PreviousStateIsValid = false;
            }
            else
            {
                playerCameraMode = MyEnum.PlayerCameraMode.Roaming;

                cinemachineRoamingCamera.m_XAxis.m_AccelTime = 0.1f;
                cinemachineRoamingCamera.m_XAxis.m_DecelTime = 0.1f;

                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.x = 0.4f;
                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.y = 0.5f;
                cinemachineRoamingCamera.GetRig(1).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.z = 0.2f;

                cinemachineRoamingCamera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.x = 0.4f;
                cinemachineRoamingCamera.GetRig(2).GetCinemachineComponent<Cinemachine.CinemachineComposer>().m_TrackedObjectOffset.y = 0.5f;

                cinemachineRoamingCamera.m_BindingMode = Cinemachine.CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp;
                cinemachineRoamingCamera.UpdateCameraState(Vector3.up, -1);
                cinemachineRoamingCamera.m_XAxis.Value = 0;
                cinemachineRoamingCamera.PreviousStateIsValid = false;
            }
        }
    }
}

