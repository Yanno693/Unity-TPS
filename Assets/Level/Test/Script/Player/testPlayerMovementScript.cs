using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMovementScript : MonoBehaviour /// Handle basic player mouvement
{
    public CharacterController characterController;
    public Camera currentCamera;
    
    // Start is called before the first frame update
    public float speed;
    public float rotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = 10.0f;
        rotation = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Character Motion (Forward and backward for now)

        Vector3 forward = new Vector3();
        forward = transform.position - currentCamera.transform.position;
        forward.y = 0;
        forward.Normalize();

        characterController.Move(forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        //characterController.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        
        
        
        transform.Rotate(0,Input.GetAxis("Horizontal") * rotation * Time.deltaTime,0);
    }
}
