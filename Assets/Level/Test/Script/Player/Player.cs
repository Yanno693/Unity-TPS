using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    // Start is called before the first frame update
    private testPlayerMovementScript movementScript;
    
    new void Start()
    {
        base.Start();
        movementScript = GetComponent<testPlayerMovementScript>();
    }

    private void DropLeftHandObject()
    {
        Carriable carriable = leftHandObject;
        carriable.carried = false;
        carriable.transform.parent = null;
        leftHandObject = null;
    }

    private void DropRightHandObject()
    {
        Carriable carriable = rightHandObject;
        carriable.carried = false;
        carriable.transform.parent = null;
        rightHandObject = null;
    }

    private void DropBothHandsObject()
    {

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if(Input.GetButton("Left Interact") && leftHandObject)
        {
            leftHandObject.Interact(this);
        }

        if(Input.GetButton("Right Interact") && rightHandObject)
        {
            rightHandObject.Interact(this);
        }

        Carriable[] carriableList = FindObjectsOfType<Carriable>();

        SortedList<float, Carriable> carriableAtProximity = new SortedList<float, Carriable>();

        foreach(Carriable carriable in carriableList)
        {
            carriable.GetComponent<Renderer>().material.SetColor("_Outline_Color", Color.black);
            
            if(!carriable.carried && (Vector3.Distance(transform.position, carriable.transform.position) < 1.5f))
            {
                Vector3 forward = movementScript.currentCamera.transform.position - transform.position;
                forward.y = 0;
                Vector2 directionForward = new Vector2(forward.x, forward.z).normalized;

                Vector3 carriableVec3 = transform.position - carriable.transform.position; // poorly named variable :(
                carriableVec3.y = 0;
                Vector2 carriableDirection = new Vector2(carriableVec3.x, carriableVec3.z).normalized;

                float angle = Mathf.Abs(Vector2.Angle(directionForward, carriableDirection));

                while(carriableAtProximity.ContainsKey(angle))
                {
                    angle += 0.001f;
                }
                carriableAtProximity.Add(angle, carriable);
            }
        }

        Carriable closestCarriable = null;

        if(carriableAtProximity.Count > 0)
        {
            closestCarriable = carriableAtProximity.Values[0];
            closestCarriable.GetComponent<Renderer>().material.SetColor("_Outline_Color", Color.white);
        }

        if(Input.GetButtonDown("Left Drag/Drop"))
        {
            if(!leftHandObject && closestCarriable)
            {
                PickUpObject(closestCarriable,false,MyEnum.Hand.Left);
            }
            else if(leftHandObject)
            {
                DropLeftHandObject();
            }
        }

        if(Input.GetButtonDown("Right Drag/Drop"))
        {
            if(!rightHandObject && closestCarriable)
            {
                PickUpObject(closestCarriable,false,MyEnum.Hand.Right);
            }
            else if(rightHandObject)
            {
                DropRightHandObject();
            }
        }
    }

    override protected void UseBothHandsObjectSecondary()
    {
        bothHandsObject.SecondaryInteract(this);
    }
}
